using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyShadow : AbstractOneTimePurchase {

    [SerializeField]
    protected GameObject shadowObject;

    protected GameObject player;

    void Awake() {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    protected override void Purchase() {
        print("Creating shadow");
        GameObject newShadow = Instantiate(shadowObject, Vector2.down, shadowObject.transform.rotation);
        
    }
}
