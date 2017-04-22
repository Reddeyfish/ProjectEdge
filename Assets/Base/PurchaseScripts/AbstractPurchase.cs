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
    protected Text buttonText;
    [SerializeField]
    protected Text labelText;

    [SerializeField]
    protected string labelFormat;

    [SerializeField]
    protected int baseCost = 1;

    //[SerializeField]
    //protected string playerPrefsKey;

    const string costFormat = "{0} Edgeyness";

    protected int numUpgrades = 0;

    //private void Awake() {
    //    if(PlayerPrefs) PlayerPrefs.
    //}

    protected virtual void OnEnable() {
        CheckPurchasable();
    }

    //Check if the player is missing health and could use healing
    protected void CheckPurchasable() {
        button.interactable = isPurchasable() && PlayerEdgeyness.getEdgeyness() >= cost();
        UpdateText();
    }

    protected virtual int cost() {
        return baseCost * (numUpgrades + 1) * (numUpgrades + 1);
    }

    protected abstract bool isPurchasable();

    /// <summary>
    /// Called by button
    /// </summary>
    public void ButtonPurchase() {
        Purchase();
        PlayerEdgeyness.changeEdgeynessBy(-cost());
        numUpgrades++;
        CheckPurchasable();
    }

    void UpdateText() {
        buttonText.text = string.Format(costFormat, cost());
        labelText.text = string.Format(labelFormat, numUpgrades + 1);
    }

    protected abstract void Purchase();

}
