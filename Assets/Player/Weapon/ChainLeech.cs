using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainLeech : MonoBehaviour {

    [SerializeField]
    protected float initialDamage = 5f; //seconds of DoT, applied immediately

    [SerializeField]
    protected int numVertices = 4;

    Rigidbody2D rigid;
    SpringJoint2D attachJoint;
    LineRenderer rend;
    Transform target;
    Vector3 attachPoint;
    Health targetHealth;

    float damageScale;

    private void Awake() {
        rigid = GetComponent<Rigidbody2D>();
        attachJoint = GetComponent<SpringJoint2D>();
        rend = GetComponent<LineRenderer>();
        rend.positionCount = numVertices;
        rend.textureMode = LineTextureMode.Tile;
        rend.useWorldSpace = false;
    }

	// Update is called once per frame
	void Update () {
        if(target == null) {
            TargetHealth_onDeath();
            return;
        }
        Vector3 destination = transform.InverseTransformPoint(target.TransformPoint(attachPoint));
        for(int i = 0; i < numVertices; i++) {
            float interpolation = ((float)(i)) / (numVertices - 1);
            rend.SetPosition(i, destination * interpolation);
        }
        targetHealth.Damage(damageScale * Time.deltaTime);
	}

    public void Init(RaycastHit2D hit, float damageScale) {
        this.damageScale = damageScale;

        this.target = hit.transform;
        attachPoint = target.InverseTransformPoint(hit.point);
        attachJoint.connectedBody = target.GetComponentInParent<Rigidbody2D>();
        attachJoint.connectedAnchor = Random.insideUnitCircle.normalized * hit.distance; 

        targetHealth = target.GetComponentInParent<Health>();
        targetHealth.onDeath += TargetHealth_onDeath;
        targetHealth.Damage(damageScale * initialDamage);

        rigid.velocity = 5 * Random.insideUnitCircle;
    }

    private void TargetHealth_onDeath() {
        attachJoint.connectedBody = null;
        SimplePool.Despawn(transform.root.gameObject);
        targetHealth.onDeath -= TargetHealth_onDeath;
    }
}
