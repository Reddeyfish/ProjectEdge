using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class HealthLossOverTime : MonoBehaviour {

    [SerializeField]
    protected float passiveHealthLossPerSecond = 0.05f;

    [SerializeField]
    protected float activeHealthLossPerSecond = 0.5f;

    Health health;

	// Use this for initialization
	void Start () {
        health = GetComponent<Health>();

    }
	
	// Update is called once per frame
	void Update () {
        health.Damage(passiveHealthLossPerSecond * Time.deltaTime);	
	}
}
