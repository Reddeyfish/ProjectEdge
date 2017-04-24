using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Health restore while at base
/// </summary>
public class BaseHealthRestore : AbstractPurchase {

    Health playerHealth;

    [SerializeField]
    private int healthRestore;

    // Use this for initialization
    void Awake() {
        playerHealth = GameObject.FindGameObjectWithTag(Tags.Player).transform.root.GetComponentInChildren<Health>();
    }

    protected override bool isPurchasable() {
        return playerHealth.healthMissing != 0;
    }

    protected override int cost() {
        return baseCost;
    }

    protected override void Purchase() {
        /* For Restoring full Health
        playerHealth.Heal(playerHealth.healthMissing);
        */
        /* For Restory some Health */
        playerHealth.Heal(healthRestore);
    }

    protected override void UpdateText() {
        base.UpdateText();
        labelText.text = string.Format(labelFormat, healthRestore);
    }
}
