using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeGunRange : AbstractPurchase {

    [SerializeField]
    private int rangeUpgrade;
    [SerializeField]
    private int maxRangeUpgrades;

    protected override bool isPurchasable() {
        return numUpgrades < maxRangeUpgrades;    
    }

    protected override void Purchase() {
        player.GetComponentInChildren<LeechGun>().changeRangeScale(rangeUpgrade);
    }

}
