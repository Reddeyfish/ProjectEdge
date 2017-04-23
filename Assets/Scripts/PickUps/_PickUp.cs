using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _PickUp : MonoBehaviour {

    [SerializeField]
    protected Sprite[] possibleSprites;

    protected GameObject attributesObject;
	// Use this for initialization
	void Start () {
        attributesObject = transform.GetChild(0).gameObject;
        SpriteRenderer spriteRend = GetComponent<SpriteRenderer>();
        spriteRend.sprite = possibleSprites[Random.Range(0, possibleSprites.Length)];
	}
	
    void OnTriggerEnter2D(Collider2D collided) {
        print("Hit");
        if (collided.CompareTag("Player")) {
            attributesObject.SetActive(true);
            attributesObject.transform.SetParent(collided.transform);

            transform.SetParent(collided.transform, transform);

            Vector3 startingLocalPosition = transform.localPosition;

            Callback.DoLerp((float l) => {
                float interpValue = Mathf.Pow(1 - l, 3);
                transform.localPosition = interpValue * startingLocalPosition;
                transform.localScale = interpValue * Vector3.one;
                }, 0.25f, this).FollowedBy(() => Destroy(gameObject), this);
        }
    }
}
