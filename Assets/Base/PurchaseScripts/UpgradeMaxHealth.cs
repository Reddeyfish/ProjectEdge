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
        base.Awake();
        playerHealth = player.transform.root.GetComponentInChildren<Health>();
    }

    protected override bool isPurchasable() {
        return true;
    }

    protected override void Purchase() {
        playerHealth.ResizeMaxHealth(playerHealth.MaxHealth + capacityIncrease);
        playerHealth.Heal(capacityIncrease);
    }

	protected override int cost() {
		return baseCost * (int)Mathf.Pow(1.65f, numUpgrades); //Mathf.
	}
}
