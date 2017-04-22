using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _PickUp : MonoBehaviour {

    protected GameObject attributesObject;
	// Use this for initialization
	void Start () {
        attributesObject = transform.GetChild(0).gameObject;
	}
	
    void OnTriggerEnter2D(Collider2D collided) {
        if (collided.CompareTag("Player")) {
            attributesObject.SetActive(true);
            attributesObject.transform.SetParent(collided.transform);

            Destroy(gameObject);
        }
    }
}
