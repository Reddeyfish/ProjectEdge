using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Health restore while at base
/// </summary>
public abstract class AbstractPurchase : MonoBehaviour {

    [SerializeField]
    protected Button button;

    [SerializeField]
    protected int cost = 1;

    protected virtual void OnEnable() {
        CheckPurchasable();
    }

    //Check if the player is missing health and could use healing
    protected void CheckPurchasable() {
        button.interactable = isPurchasable() && PlayerEdgeyness.getEdgeyness() >= cost;
    }

    protected abstract bool isPurchasable();

    /// <summary>
    /// Called by button
    /// </summary>
    public void ButtonPurchase() {
        Purchase();
        PlayerEdgeyness.changeEdgeynessBy(-cost);
        CheckPurchasable();
    }

    protected abstract void Purchase();

}
