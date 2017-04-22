using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Health restore while at base
/// </summary>
public class BaseHealthRestore : MonoBehaviour {

    [SerializeField]
    protected Button button;

    [SerializeField]
    protected int edgeCost = 1;
    [SerializeField]
    protected float healthGain = 1;

    Health playerHealth; 

	// Use this for initialization
	void Awake () {
        playerHealth = GameObject.FindGameObjectWithTag(Tags.Player).transform.root.GetComponentInChildren<Health>();
    }

    private void OnEnable() {
        CheckHealable();
    }

    //Check if the player is missing health and could use healing
    void CheckHealable() {
        button.interactable = playerHealth.healthMissing != 0 && PlayerEdgeyness.getEdgeyness() >= edgeCost;
    }

    /// <summary>
    /// Called by button
    /// </summary>
    public void RestoreHealth() {
        playerHealth.Heal(healthGain);
        PlayerEdgeyness.changeEdgeynessBy(-1);
        //reduce edgeyness here

        CheckHealable();

        //play sound?
    }
}
