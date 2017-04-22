using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Health restore while at base
/// </summary>
public class UpgradeEdgeynessCapacity : AbstractPurchase {

    [SerializeField]
    protected int capacityUpgrade = 50;

    protected override bool isPurchasable() {
        return true;
    }

    protected override void Purchase() {
        PlayerEdgeyness.setMaxTempEdgeyness(PlayerEdgeyness.getMaxTempEdgeyness() + capacityUpgrade);
    }
}
