using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MeteorCrashing : MonoBehaviour {

    private Vector2 previousVelocity;

    protected Rigidbody2D rgdBody;
    public int damage;
    public float crashLength;

    [SerializeField]
    protected float crashStrengthMultiplier = 1;

    [SerializeField]
    private GameObject playerPushBack;

    private float currentCrashTime = 0;
    
    //Player attributes
    private GameObject player;
    private Rigidbody2D playerRB;

	// Use this for initialization
	void Start () {
        rgdBody = GetComponent<Rigidbody2D>();

        //Get player attributes
        player = GameObject.FindGameObjectWithTag("Player");

        previousVelocity = rgdBody.velocity;
    }

    void FixedUpdate() {
        previousVelocity = rgdBody.velocity;
    }

    private bool canCrash() {
        //float angleOfVelocity = Mathf.Atan2(rgdBody.velocity.y, rgdBody.velocity.x);
        //float angleBetweenPlayerAndSelf = (Mathf.Atan2(player.transform.position.y - transform.position.y, player.transform.position.x - transform.position.x));
        //angleOfVelocity += angleOfVelocity < 0 ? 2 * Mathf.PI : 0;
        //angleBetweenPlayerAndSelf += angleBetweenPlayerAndSelf < 0 ? 2 * Mathf.PI : 0;
        //angleOfVelocity *= (180 / Mathf.PI);
        //angleBetweenPlayerAndSelf *= (180 / Mathf.PI);

        //print(angleOfVelocity + " | " + angleBetweenPlayerAndSelf);

        //return Mathf.Abs(angleOfVelocity - angleBetweenPlayerAndSelf) < 90;
        
        Vector2 directionBetweenPlayerAndSelf = new Vector2(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y);
        
        float dotProduct_CurVelocityAndDir = Vector2.Dot(directionBetweenPlayerAndSelf, previousVelocity);
        float lengthMultiply = directionBetweenPlayerAndSelf.magnitude * previousVelocity.magnitude;
        
        return Mathf.Acos(dotProduct_CurVelocityAndDir / lengthMultiply) < 80 * Mathf.Deg2Rad;


    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Player") && canCrash()) {
            collision.gameObject.GetComponent<StrikePlayer>().Strike(collision.transform, crashLength, damage, previousVelocity, transform.position);
            //GameObject tempPrefabPushBack = Instantiate(playerPushBack, collision.transform);
            //tempPrefabPushBack.GetComponent<PlayerPushBack>().Init(crashLength, damage, previousVelocity, transform.position);
        }
        previousVelocity = rgdBody.velocity;
    }
}
