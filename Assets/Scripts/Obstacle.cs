using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
   void OnCollisionEnter(Collision collision)
    {
        GameObject otherObj = collision.gameObject;
        Debug.Log("Collided with: " + otherObj);


        if (collision.gameObject.tag == "Player")
        {
            //GameObject otherObj = collision.gameObject;
            //Debug.Log("Collided with: " + otherObj);

        }
    }
    // Update is called once per frame
 //   void Update () {
	 
	//}
}
