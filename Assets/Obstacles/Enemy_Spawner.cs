using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spawner : MonoBehaviour {

    public GameObject Basic;
    public GameObject BiggerBasic;
    public GameObject Hunter;
    public GameObject Star;//what to spawn; 
    GameObject player; // player
    GameObject Base;//base
    public int numberOfObjects = 20;   // Maximum obstacles near by the player;
    public float radius = 40f; // spawn range;
    public float minRadius = 30f;
    Vector3 player_position; // player position;

    GameObject[] obstacles; // array to detect all obstacles around you 
    GameObject[] enemies; //prefabs of all enemies
    int count;


    float distance; //distance from base



    public float timer = 3f;
    private float actualTimer;
    float current_time;
    
    // Use this for initialization
    void Start()
    {

      player = GameObject.FindGameObjectWithTag("Player");
        enemies = new GameObject[5];
        enemies[0] = Basic;
        enemies[1] = Hunter;
        enemies[2] = Star;
        enemies[3] = Basic;
        enemies[4] = BiggerBasic;

        //hard coded percentage;


    }
   
    // Update is called once per frame
    void Update()
    {
       obstacles= GameObject.FindGameObjectsWithTag("Obstacle");
        count = obstacles.Length;

        player_position = new Vector3(player.transform.position.x, player.transform.position.y, 0);

        Spawn();

    }
    void Spawn()
    {
        Base = GameObject.FindGameObjectWithTag("Base");
        distance = Vector3.Distance(this.transform.position, Base.transform.position);
//        Debug.Log(distance);
        numberOfObjects = (int)(distance/3)-1;

        actualTimer = Mathf.Clamp(timer - timer * (((int) (distance/30))/20f), .1f, timer);

        if (count < numberOfObjects)
        {
            if (current_time < actualTimer)
            {
                current_time += Time.deltaTime;
            }

            else
            {
                current_time = 0;
                //Debug.Log("Too Little,Spawn more edge.");
                Vector3 pos = (Vector3)(Random.insideUnitCircle.normalized * Random.Range(minRadius, radius)) + player.transform.position; 

                int index = Random.Range(0, enemies.Length);
                 Instantiate(enemies[index], pos, Quaternion.identity);


                }

            }
            
        }
    }


