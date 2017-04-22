using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPushBack : MonoBehaviour {

    private int damage;
    private CameraShakeScript camShake;
    private float crashLength;
    private float currentVelocity;

    //Player attributes
    private GameObject player;
    private Health playerHealth;
    private PlayerMovement playerMovement;
    private Rigidbody2D playerRB;

    // Use this for initialization
    void Start () {
        
    }

    public void Init(float crashLength, int damage, float currentVelocity) {
        this.crashLength = crashLength;
        this.damage = damage;
        this.currentVelocity = currentVelocity;
        print(currentVelocity);

        camShake = Camera.main.GetComponent<CameraShakeScript>();

        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<Health>();
        playerMovement = player.GetComponent<PlayerMovement>();
        playerRB = player.GetComponent<Rigidbody2D>();

        StartCoroutine(crashPlayer());
    }

    protected IEnumerator crashPlayer() {
        float currentCrashTime = 0;

        playerHealth.Damage(damage);
        playerMovement.enabled = false;

        camShake.screenShake(crashLength / 2);

        Vector2 direction = (player.transform.position - transform.position).normalized;
        
        playerRB.velocity = direction * currentVelocity;

        while (currentCrashTime < crashLength) {

            currentCrashTime += Time.deltaTime;
            print(string.Format("Getting crashed"));
            yield return 0;
        }
        //yield return new WaitForSeconds(crashLength);
        
        playerMovement.enabled = true;

        Destroy(gameObject);
    }
}
