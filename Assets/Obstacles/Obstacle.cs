using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {
    GameObject player;

    public float detection_range = 30f; // If exceed this range the object self-destructs.

    public float movement_speed = 30f; // how fast the object is going on start.
    public float minimum_speed = 0f;

    private Rigidbody2D rb;

    private void Start()
    {
      
        rb = GetComponent<Rigidbody2D>();

        StartCoroutine(increaseSpeed());

    }
    private IEnumerator increaseSpeed() {
        int i = 0;
        Vector2 chosenVector = new Vector2(Random.Range(-5, 5), Random.Range(-5, 5)) * movement_speed;
        if (chosenVector.sqrMagnitude < 1)
            Vector3.Normalize(chosenVector);

        while (rb.velocity.magnitude < minimum_speed && i++ < 10000) {
            rb.AddForce(chosenVector);
            print(rb.velocity.magnitude);
            yield return 0;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.name == "Player")
        {
            Debug.Log("Bump");
        }
    }


   // Update is called once per frame
       void Update()  //self_destruct things;
    {
        player = GameObject.FindGameObjectWithTag("Player");
        float distance = Vector3.Distance(this.transform.position, player.transform.position);
      //  Debug.Log(distance);
        if (distance > detection_range)
            Destroy(gameObject);
    }
}
