using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyShadow : AbstractPurchase {

    [SerializeField]
    protected GameObject shadowObject;

    protected GameObject player;

    void Awake() {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    protected override bool isPurchasable() {
        return true;
    }

    protected override void Purchase() {
        GameObject newShadow = Instantiate(shadowObject, Vector2.down, shadowObject.transform.rotation);
        
    }
}
