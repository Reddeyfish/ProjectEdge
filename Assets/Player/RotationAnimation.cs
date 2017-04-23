using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationAnimation : MonoBehaviour {

    [SerializeField]
    protected float cycleTime = 1f;

    [SerializeField]
    protected float scale = 45f;

    [SerializeField]
    protected float offset = 90f;

    [SerializeField]
    protected AnimationCurve rotationOverTime = AnimationCurve.Linear(0, 0, 1, 0);

    private void Update() {
        float evaluationTime = (Time.time / cycleTime) % 1;
        float animationValue = scale * rotationOverTime.Evaluate(evaluationTime) + offset;
        transform.localRotation = Quaternion.AngleAxis(animationValue, Vector3.forward);
    }
}
