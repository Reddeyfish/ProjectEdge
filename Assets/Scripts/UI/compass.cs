using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class compass : MonoBehaviour {

    public bool active = false;

    public GameObject target;
    public GameObject player;

	// Use this for initialization
	void Start () {
        transform.localScale = new Vector3(0, 0, 0);
	}

    public void setActive() { active = true; }

	// Update is called once per frame
	void Update () {
        if (active) { transform.localScale = new Vector3(1, 1, 1); }
        else { transform.localScale = new Vector3(0, 0, 0); }
        
        Vector3 relativePos = target.transform.position - player.transform.position;
        Quaternion rotation = Quaternion.LookRotation(relativePos, transform.TransformDirection(Vector3.up));
        transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);
	}
}
