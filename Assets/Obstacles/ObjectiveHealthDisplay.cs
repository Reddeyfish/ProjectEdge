using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveHealthDisplay : MonoBehaviour {

    Renderer rend;
    Health health;

    void Start() {
        rend = GetComponent<Renderer>();
        health = GetComponent<Health>();
        health.onHealthChanged += Health_onHealthChanged;
        Health_onHealthChanged();
    }

    private void Health_onHealthChanged() {
        MaterialPropertyBlock instancedData = new MaterialPropertyBlock();
        rend.GetPropertyBlock(instancedData);
        float alphaThreshold = (1 - health.healthPercent)/2;
        instancedData.SetFloat("_AlphaThreshold", alphaThreshold);

        float colorOffset = Mathf.Min(alphaThreshold, 1 - alphaThreshold); //value is the distance to the nearest whole number
        colorOffset /= 2; //scale the output range from [0..0.5] to [0..0.25]
        instancedData.SetFloat("_ColorOffset", colorOffset);

        rend.SetPropertyBlock(instancedData);
    }
}
