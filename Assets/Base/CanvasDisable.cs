using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasDisable : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Disable() {
        this.gameObject.SetActive(false);
    }
}
