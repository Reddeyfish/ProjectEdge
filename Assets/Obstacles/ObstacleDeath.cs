using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleDeath : MonoBehaviour {

    Health health;

    private void Awake() {
        health = GetComponentInParent<Health>();
        health.onDeath += Health_onDeath;
    }

    private void Health_onDeath() {
        Destroy(this.transform.root.gameObject);
    }
}
