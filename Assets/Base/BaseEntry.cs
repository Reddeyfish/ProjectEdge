using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEntry : MonoBehaviour {

    [SerializeField]
    protected Canvas baseScreen;

    [SerializeField]
    protected Canvas baseTooltip;

    private void OnTriggerEnter2D(Collider2D other) {
        baseTooltip.gameObject.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D other) {
        baseTooltip.gameObject.SetActive(false);
    }

    private void Update() {
        if(baseTooltip.isActiveAndEnabled) {
            if(Input.GetKeyDown(KeyCode.Space)) {
                baseScreen.gameObject.SetActive(true);
            }
        }
    }
}
