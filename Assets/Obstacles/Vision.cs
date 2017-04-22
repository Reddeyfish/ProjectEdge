using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vision : MonoBehaviour {

    GameObject Parent_Hunter;
    Vector3 Prey;

    Rigidbody2D rigid;
    public float hunter_speed = 4000;

    bool chase = false;
	// Use this for initialization
	void Start () {
        rigid = GetComponentInParent<Rigidbody2D>();
        Parent_Hunter = transform.root.gameObject;
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Prey = other.transform.position;
            chase = true;
           // Make parent chase player
        }



    }
    // Update is called once per frame
    void Update () {
		
        //chasing Player
        if(chase)
        {
            Vector2 targetDirection = Prey - this.transform.position;
            targetDirection.Normalize();
            rigid.velocity = Vector2.MoveTowards(rigid.velocity, hunter_speed*targetDirection, Time.deltaTime *1);

        }
    }
}
