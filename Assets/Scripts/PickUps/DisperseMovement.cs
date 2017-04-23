using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisperseMovement : MonoBehaviour {

    public float startSpeed = 25f;
    public float deccel = .75f;
    private Rigidbody2D rb;


	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Random.insideUnitCircle * startSpeed;
	}
	
	// Update is called once per frame
	void Update () {
        rb.velocity = Vector2.ClampMagnitude(Vector2.MoveTowards(rb.velocity, Vector2.zero, startSpeed * deccel * Time.deltaTime), startSpeed);
        if (rb.velocity.sqrMagnitude < 1) {
            rb.velocity = Vector3.zero;
            Destroy(this);
        }
	}
}
