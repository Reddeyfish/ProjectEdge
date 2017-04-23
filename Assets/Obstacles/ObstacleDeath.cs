using System.Collections;
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
        float amount = 1 + (distance / 80) + Random.value; //random for dithering
        for (int i = 0; i < amount; i++) {
            Instantiate(spawnOnDeath, transform.position, new Quaternion());
        }

        SimplePool.Spawn(deathEffects);

        Destroy(this.transform.root.gameObject);
    }
}
