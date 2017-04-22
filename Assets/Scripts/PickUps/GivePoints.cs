using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GivePoints : _PickUpAttribute {

    private Health playerHealth;

    [SerializeField]
    protected int points;

	// Use this for initialization
	void Start () {
        base.Start();
        playerHealth = player.GetComponent<Health>();
        activate();
	}

    public override void activate() {
        //player.transform.localScale *= 3;
        playerEdgeyness.changeTempEdgeynessBy(points);
        playerHealth.Damage(1);

        DeleteSelf();
    }
}
