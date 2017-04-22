using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class _PickUpAttribute : MonoBehaviour {

    protected GameObject player;
    protected PlayerEdgeyness playerEdgeyness;

	// Use this for initialization
	protected void Start () {
        player = transform.parent.gameObject;
        playerEdgeyness = player.GetComponent<PlayerEdgeyness>();
	}

    public abstract void activate();
    public void DeleteSelf() {
        Destroy(gameObject);
    }
}
