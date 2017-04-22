using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {
    GameObject player;

    public float detection_range = 30f;

    public float movement_speed = 30f;
    private void Start()
    {
      
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(Random.Range(-5,5)*movement_speed,Random.Range(-5,5)*movement_speed));

    }
    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.name == "Player")
        {
            Debug.Log("Bump");
        }
    }


   // Update is called once per frame
       void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        float distance = Vector3.Distance(this.transform.position, player.transform.position);
      //  Debug.Log(distance);
        if (distance > detection_range)
            Destroy(gameObject);
    }
}
