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
        GameObject newShadow = Instantiate(shadowObject, new Vector2(), new Quaternion(0, 0, 90, 0), player.transform);
        newShadow.transform.localPosition = new Vector2(-1, 0);
        newShadow.transform.localRotation = Quaternion.Euler(0, 0, -90);

    }
}
