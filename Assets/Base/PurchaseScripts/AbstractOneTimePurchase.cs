using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractOneTimePurchase : AbstractPurchase {

	// Use this for initialization
	void Start () {
        if (!PlayerPrefs.HasKey(playerPrefsKey)) { return; }

        int numExistingUpgrades = PlayerPrefs.GetInt(playerPrefsKey);

        if (numExistingUpgrades > 0) {
            Purchase();
            numUpgrades = 1;
        }
        CheckPurchasable();
	}

    protected override bool isPurchasable() {
        return numUpgrades == 0;
    }

    protected override int cost() {
        return baseCost;
    }

    protected override void UpdateText() {
        print("Updated");
        if (numUpgrades == 0) {
            buttonText.text = string.Format(costFormat, cost());
            labelText.text = string.Format(labelFormat, "");
        }
        else {
            buttonText.text = "Bought";
            labelText.text = string.Format(labelFormat, "");
        }
    }
	
}
