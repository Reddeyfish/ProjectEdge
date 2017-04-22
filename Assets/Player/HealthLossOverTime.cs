using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class HealthLossOverTime : MonoBehaviour {

    PlayerMovement movement;

    [SerializeField]
    protected float passiveHealthLossPerSecond = 0.05f;

    [SerializeField]
    protected float activeHealthLossPerSecond = 0.5f;

    Health health;

	// Use this for initialization
	void Start () {
        movement = GetComponentInParent<PlayerMovement>();
        health = GetComponent<Health>();
    }
	
	// Update is called once per frame
	void Update () {
        float healthLoss;
        if(movement.normalizedMovementInput.sqrMagnitude > 0) {
            //actively moving
            healthLoss = activeHealthLossPerSecond * Time.deltaTime;
        } else {
            //drifting
            healthLoss = passiveHealthLossPerSecond * Time.deltaTime;
        }
        health.Damage(healthLoss);	
	}
}
