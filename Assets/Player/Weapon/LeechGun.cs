using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeechGun : MonoBehaviour {

    PlayerMovement input;
    LayerMask mask;

    [SerializeField]
    protected GameObject leechPrefab;

    public float range = 10f;

    public float damageScale = 10.0f;

	// Use this for initialization
	void Awake () {
        input = GetComponentInParent<PlayerMovement>();
        mask = LayerMask.GetMask(Tags.Layers.Enemy);
	}
	
	// Update is called once per frame
	void Update () {
        if (!Input.GetMouseButtonDown(0)) { return; }
        Vector2 aimingDirection = input.rawAimingInput.normalized;


        RaycastHit2D hit = Physics2D.Raycast(transform.position, aimingDirection, range, mask);
        if (!hit) { return; }

        GameObject leech = SimplePool.Spawn(leechPrefab, transform.position);
        leech.GetComponent<ChainLeech>().Init(hit, damageScale);

        //health cost

        //reload
	}
}
