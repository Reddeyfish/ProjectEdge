using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Base_ShowEdgeyness : MonoBehaviour {

    private static Text text;

    // Use this for initialization
	void Awake () {
        text = GetComponent<Text>();
	}
	
	void OnEnable() {
        updateText();
    }

    public static void updateText() {
        text.text = "Edgeyness Count: " + PlayerEdgeyness.getEdgeyness();
    }
}
