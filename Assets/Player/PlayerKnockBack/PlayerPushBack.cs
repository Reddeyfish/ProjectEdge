using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPushBack : MonoBehaviour {

    private int damage;
    private CameraShakeScript camShake;
    private float crashLength;
    private Vector2 currentVelocity;
    private Vector2 currentPosition;

    //Player attributes
    private GameObject player;
    private Health playerHealth;
    private PlayerMovement playerMovement;
    private Rigidbody2D playerRB;

    private bool pushForward = true;

    // Use this for initialization
    void Start () {
        
    }

    public void Init(float crashLength, int damage, Vector2 currentVelocity, Vector2 currentPosition) {
        this.crashLength = crashLength;
        this.damage = damage;
        this.currentVelocity = currentVelocity;
        this.currentPosition = currentPosition;

        camShake = Camera.main.GetComponent<CameraShakeScript>();

        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<Health>();
        playerMovement = player.GetComponent<PlayerMovement>();
        playerRB = player.GetComponent<Rigidbody2D>();

        StartCoroutine(crashPlayer());
    }

    public void Init(float crashLength, int damage, Vector2 currentVelocity, Vector2 currentPosition, bool pushForward) {
        this.pushForward = pushForward;
        this.Init(crashLength, damage, currentVelocity, currentPosition);
    }

    protected IEnumerator crashPlayer() {
        float currentCrashTime = 0;

        playerHealth.Damage(damage);
        playerMovement.enabled = false;

        camShake.screenShake(crashLength * (3/4f));

        Vector2 pushDirection = (((Vector2)player.transform.position - currentPosition).normalized + currentVelocity.normalized * 2).normalized;

        Vector2 direction = pushDirection * (pushForward ? 1 : -1);
        
        playerRB.velocity = direction * currentVelocity.magnitude;

        while (currentCrashTime < crashLength) {

            currentCrashTime += Time.deltaTime;
            yield return 0;
        }
        //yield return new WaitForSeconds(crashLength);
        
        playerMovement.enabled = true;

        Destroy(gameObject);
    }
}
