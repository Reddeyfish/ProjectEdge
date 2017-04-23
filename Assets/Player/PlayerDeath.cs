using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour {

    Health health;
    [SerializeField]
    protected GameObject deathPrefab;

	// Use this for initialization
	void Start () {
        health = GetComponent<Health>();
        health.onDeath += Health_onDeath;
	}

    private void Health_onDeath() {
        foreach (Renderer rend in transform.root.GetComponentsInChildren<Renderer>()) { rend.enabled = false; }

        Instantiate(deathPrefab);
        health.onDeath -= Health_onDeath;
    }
}
