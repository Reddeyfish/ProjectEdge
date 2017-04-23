using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeechGun : MonoBehaviour {

    PlayerMovement input;
    LayerMask mask;
    Health health;

    [SerializeField]
    protected LineRenderer rend;

    [SerializeField]
    protected GameObject leechPrefab;

    [SerializeField]
    protected float healthCost;

    [SerializeField]
    protected float cycleTime = 0.5f;

    public float range = 10f;

    public float damageScale = 10.0f;

    float lastShotTime = 0;

	// Use this for initialization
	void Awake () {
        input = GetComponentInParent<PlayerMovement>();
        mask = LayerMask.GetMask(Tags.Layers.Enemy);
        health = GetComponentInParent<Health>();

    }
	
	// Update is called once per frame
	void Update () {
        if(Time.timeScale == 0) {return; } // paused 
        if (lastShotTime + cycleTime >= Time.time) { return; }
        if (!Input.GetMouseButtonDown(0)) { return; }
        Debug.Log(lastShotTime + 1f >= Time.time);
        Vector2 aimingDirection = input.rawAimingInput.normalized;


        RaycastHit2D hit = Physics2D.Raycast(transform.position, aimingDirection, range, mask);

        float distance = hit ? hit.distance : range;

        rend.transform.localScale = new Vector3(1, range, 1);
        Quaternion rotation = aimingDirection.ToRotation() * Quaternion.AngleAxis(-90, Vector3.forward);
        rend.transform.rotation = rotation;
        rend.gameObject.SetActive(true);

        Callback.DoLerp((float l) => {
            MaterialPropertyBlock block = new MaterialPropertyBlock();
            block.SetFloat("_DistortionStrength", Mathf.Lerp(0.25f, 0, l));
            block.SetFloat("_Cutoff", distance / range);
            block.SetFloat("_Alpha", 1 - l);
            block.SetVector("_Direction", aimingDirection);
            rend.SetPropertyBlock(block);
        }, cycleTime, this).FollowedBy(() => rend.gameObject.SetActive(false), this);

        lastShotTime = Time.time;

        //health cost
        health.Damage(healthCost);

        if (!hit) { return; }

        GameObject leech = SimplePool.Spawn(leechPrefab, transform.position);
        leech.GetComponent<ChainLeech>().Init(hit, damageScale);
    }
}
