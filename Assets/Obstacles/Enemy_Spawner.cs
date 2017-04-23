using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spawner : MonoBehaviour {

    public GameObject Basic;
    public GameObject Hunter;
    public GameObject Star;//what to spawn; 
    GameObject player; // player
    public int numberOfObjects = 20;   // Maximum obstacles near by the player;
    public float radius = 40f; // spawn range;
    Vector3 player_position; // player position;

    GameObject[] obstacles; // array to detect all obstacles around you 
    GameObject[] enemies; //prefabs of all enemies
    int count;




    public float timer = 3f;
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
        enemies[4] = Basic;

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
     
        if (count < numberOfObjects)
        {
            if (current_time < timer)
            {
                current_time += Time.deltaTime;
            }

            else
            {
                current_time = 0;
                Debug.Log("Too Little,Spawn more edge.");
                    Vector3 pos = new Vector3(Random.Range(player_position.x - radius, player_position.x + radius),
                        Random.Range(player_position.y - radius, player_position.y + radius), 0);

                int index = Random.Range(0, enemies.Length);
                 Instantiate(enemies[index], pos, Quaternion.identity);


                }

            }
            
        }
    }


