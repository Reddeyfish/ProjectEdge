using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPowerUp : _PickUpAttribute {

	// Use this for initialization
	void Start () {
        base.Start();
        activate();
	}

    protected override void activate() {
        player.transform.localScale *= 3;
        playerEdgeyness.changeEdgeynessBy(50);

        print(playerEdgeyness.getEdgeyness());

        DeleteSelf();
    }
}
