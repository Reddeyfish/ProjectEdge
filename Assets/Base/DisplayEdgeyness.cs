using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayEdgeyness : MonoBehaviour {

    [SerializeField]
    protected Text text;    

    private void Awake() {
        PlayerEdgeyness.onEdgeynessChange += PlayerEdgeyness_onEdgeynessChange;
        PlayerEdgeyness_onEdgeynessChange();
    }

    void OnEnable() {
        PlayerEdgeyness.onEdgeynessChange += PlayerEdgeyness_onEdgeynessChange;
    }

    void OnDisable() {
        PlayerEdgeyness.onEdgeynessChange -= PlayerEdgeyness_onEdgeynessChange;
    }

    private void PlayerEdgeyness_onEdgeynessChange() {
        text.text = string.Format("Edgeyness: {0}", PlayerEdgeyness.getEdgeyness());
    }
}
