using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting_Star : MonoBehaviour
{

    GameObject player; //Fing the player
    Vector2 targetDirection;
    public float detection_range = 100f; // If exceed this range the object self-destructs.

    public float movement_speed = 100f; // how fast the object is going on start.
    private void Start()
    {

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(Random.Range(-5, 5) * movement_speed, Random.Range(-5, 5) * movement_speed));

        player = GameObject.FindGameObjectWithTag("Player");


        float angle = 0; //look at 2D
        Vector3 relative = transform.InverseTransformPoint(player.transform.position);
        angle = Mathf.Atan2(relative.x, relative.y) * Mathf.Rad2Deg;
        Debug.Log(-angle);
        transform.Rotate(0, 0, Random.Range(-angle+20,-angle-20));

    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.name == "Player")
        {
            Debug.Log("Justice rain from above lol");
        }
    }


    // Update is called once per frame
    void Update()  //self_destruct things;
    {

        this.GetComponent<Rigidbody2D>().velocity = (transform.up * movement_speed);
  




        float distance = Vector3.Distance(this.transform.position, player.transform.position);
        //  Debug.Log(distance);
        if (distance > detection_range)
            Destroy(gameObject);
    }
}