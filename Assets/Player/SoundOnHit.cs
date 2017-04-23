using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundOnHit : MonoBehaviour {

    AudioSource audioSource;

    [SerializeField]
    protected float threshold = 5;

	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
        GetComponent<Health>().onDamage += SoundOnHit_onDamage;

    }

    private void SoundOnHit_onDamage(float amount) {
        if (amount > threshold) {
            audioSource.Play();
        }
    }
}
