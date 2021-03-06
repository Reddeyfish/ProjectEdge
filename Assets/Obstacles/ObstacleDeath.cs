﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleDeath : MonoBehaviour {

    public GameObject spawnOnDeath; //rewards/loot

    [SerializeField]
    protected GameObject deathEffects;

    Health health;

    private void Awake() {
        health = GetComponentInParent<Health>();
        health.onDeath += Health_onDeath;
    }

    private void Health_onDeath() {
        float distance = transform.position.magnitude;
        float amount = 1 + (distance / 80) + Random.value + (PlayerPrefs.HasKey("BuyShadow") ? 1 : 0); //random for dithering, Shadow for more spawns
        for (int i = 0; i < amount; i++) {
            Instantiate(spawnOnDeath, transform.position, new Quaternion());
        }

        if (deathEffects)
            SimplePool.Spawn(deathEffects);

        Destroy(this.transform.root.gameObject);
    }
}
