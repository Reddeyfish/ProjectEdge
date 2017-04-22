using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Health restore while at base
/// </summary>
public class UpgradeMaxHealth : AbstractPurchase {

    [SerializeField]
    protected float capacityIncrease = 50f;

    Health playerHealth;

    // Use this for initialization
    void Awake() {
        playerHealth = GameObject.FindGameObjectWithTag(Tags.Player).transform.root.GetComponentInChildren<Health>();
    }

    protected override bool isPurchasable() {
        return true;
    }

    protected override void Purchase() {
        playerHealth.ResizeMaxHealth(playerHealth.MaxHealth + capacityIncrease);
        playerHealth.Heal(capacityIncrease);
    }
}
