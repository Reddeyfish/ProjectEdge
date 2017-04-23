using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrikePlayer : MonoBehaviour {
    
    [SerializeField]
    public GameObject playerPushBack;
    
	public void Strike(Transform collision, float crashLength, int damage, Vector2 velocityPower, Vector2 currentPos) {
        GameObject tempPrefabPushBack = Instantiate(playerPushBack, collision);
        tempPrefabPushBack.GetComponent<PlayerPushBack>().Init(crashLength, damage, velocityPower, currentPos);
    }
}
