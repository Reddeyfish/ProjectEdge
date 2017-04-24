using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrikePlayer : MonoBehaviour {
    
    [SerializeField]
    public GameObject playerPushBack;
    
	public void Strike(Transform playerTransform, float crashLength, int damage, Vector2 velocityPower, Vector2 currentPos, bool pushForward = true) {
        GameObject tempPrefabPushBack = Instantiate(playerPushBack, playerTransform);
        tempPrefabPushBack.GetComponent<PlayerPushBack>().Init(crashLength, damage, velocityPower, currentPos, pushForward);
    }

}
