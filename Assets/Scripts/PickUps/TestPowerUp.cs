using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPowerUp : _PickUpAttribute {

    private Health playerHealth;
	// Use this for initialization
	void Start () {
        base.Start();
        playerHealth = player.GetComponent<Health>();
        activate();
	}

    public override void activate() {
        //player.transform.localScale *= 3;
        playerEdgeyness.changeTempEdgeynessBy(50);
        playerHealth.Damage(1);

        DeleteSelf();
    }
}
