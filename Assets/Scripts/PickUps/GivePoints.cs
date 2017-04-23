using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GivePoints : _PickUpAttribute {

    private Health playerHealth;

    [SerializeField]
    protected int points;

	// Use this for initialization
	new void Start () {
        base.Start();
        playerHealth = player.GetComponent<Health>();
        activate();
	}

    public override void activate() {
        playerEdgeyness.changeTempEdgeynessBy(points);

        DeleteSelf();
    }

    public override bool canCollect() {
        return PlayerEdgeyness.getTempEdgeyness() < PlayerEdgeyness.getMaxTempEdgeyness();
    }
}
