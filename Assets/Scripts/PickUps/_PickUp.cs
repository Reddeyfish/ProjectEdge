using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _PickUp : MonoBehaviour {

    [SerializeField]
    protected Sprite[] possibleSprites;

    protected GameObject attributesObject;
    protected _PickUpAttribute attribute;
	// Use this for initialization
	void Start () {
        attributesObject = transform.GetChild(0).gameObject;
        attribute = attributesObject.GetComponent<_PickUpAttribute>();

        SpriteRenderer spriteRend = GetComponent<SpriteRenderer>();
        spriteRend.sprite = possibleSprites[Random.Range(0, possibleSprites.Length)];
	}
	
    void OnTriggerEnter2D(Collider2D collided) {

        if (collided.CompareTag("Player")) {
            if (!attribute.canCollect()) {
                //Do something?
                return;
            }


            attributesObject.SetActive(true);
            attributesObject.transform.SetParent(collided.transform);

            transform.SetParent(collided.transform, transform);

            Vector3 startingLocalPosition = transform.localPosition;

            GetComponent<Collider2D>().enabled = false;
            GetComponent<AudioSource>().Play();

            Callback.DoLerp((float l) => {
                float interpValue = Mathf.Pow(1 - l, 3);
                transform.localPosition = interpValue * startingLocalPosition;
                transform.localScale = interpValue * Vector3.one;
                }, 0.25f, this).FollowedBy(() => Destroy(gameObject), this);
        }
    }
}
