using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Health restore while at base
/// </summary>
public class BaseHealthRestore : AbstractPurchase {

    [SerializeField]
    protected float healthGain = 1;

    Health playerHealth;

    // Use this for initialization
    void Awake() {
        playerHealth = GameObject.FindGameObjectWithTag(Tags.Player).transform.root.GetComponentInChildren<Health>();
    }

    protected override bool isPurchasable() {
        return playerHealth.healthMissing != 0 && PlayerEdgeyness.getEdgeyness() > 0;
    }

    protected override int cost() {
        return baseCost * (Mathf.Min(PlayerEdgeyness.getEdgeyness(), Mathf.CeilToInt(playerHealth.healthMissing)));
    }

    protected override void Purchase() {
        playerHealth.Heal(Mathf.Min(PlayerEdgeyness.getEdgeyness(), Mathf.CeilToInt(playerHealth.healthMissing)));
    }
}
