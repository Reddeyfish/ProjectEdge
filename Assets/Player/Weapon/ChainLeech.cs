using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainLeech : MonoBehaviour {

    [SerializeField]
    protected float initialDamage = 5f; //seconds of DoT, applied immediately

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
    }

	// Update is called once per frame
	void Update () {
        rend.SetPosition(1, transform.InverseTransformPoint(target.TransformPoint(attachPoint)));
        targetHealth.Damage(damageScale * Time.deltaTime);
	}

    public void Init(RaycastHit2D hit, float damageScale) {
        this.damageScale = damageScale;

        this.target = hit.transform;
        attachPoint = target.InverseTransformPoint(hit.point);
        attachJoint.connectedBody = target.GetComponentInParent<Rigidbody2D>();
        attachJoint.connectedAnchor = attachPoint;
        attachJoint.distance = hit.distance;

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
