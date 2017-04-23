using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hunter_Damage : MonoBehaviour {

    public float damageInterval = 1f;
    public int damage = 10;
    public float crashLength = .4f;
    private float timeCounter;
    

    void OnTriggerStay2D(Collider2D collided) {
        if (!collided.gameObject.CompareTag("Player"))
            return;
        timeCounter += Time.deltaTime;
        if (timeCounter > damageInterval) {
            collided.GetComponent<StrikePlayer>().Strike(collided.transform, crashLength, damage, (collided.transform.position - transform.position).normalized, transform.position);
            timeCounter = 0;
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if (!other.gameObject.CompareTag("Player"))
            return;
        timeCounter = 0;
    }
}
