using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeDamage : AbstractPurchase {

    [SerializeField]
    protected int damageUpgrade;
    [SerializeField]
    protected int maxDamageUpgrades;

    protected override bool isPurchasable() {
        return numUpgrades < maxDamageUpgrades;
    }

    protected override void Purchase() {
        LeechGun gun = GameObject.FindGameObjectWithTag(Tags.Player).GetComponentInChildren<LeechGun>();
        gun.changeDamageScale(damageUpgrade);
    }
	protected override int cost() {
		return baseCost * (int)Mathf.Pow(2, numUpgrades); //Mathf.
	}
}
