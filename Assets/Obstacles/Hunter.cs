using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hunter : MonoBehaviour {

    GameObject player;

 
    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
       // sight = this.gameObject.transform.GetChild(0);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.name == "Player")
        {
            Debug.Log("I've got you in my sight.");
        }
    }
    // Update is called once per frame
    void Update () {

        float angle = 0; //look at 2D
        Vector3 relative = transform.InverseTransformPoint(player.transform.position);
        angle = Mathf.Atan2(relative.x, relative.y) * Mathf.Rad2Deg;
        transform.Rotate(0, 0, -angle);
    }
}
