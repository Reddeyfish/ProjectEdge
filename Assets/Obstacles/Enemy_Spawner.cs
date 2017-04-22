using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spawner : MonoBehaviour {

    public GameObject prefab;
    GameObject player;
    public int numberOfObjects = 20;
    public float radius = 10f;
    Vector3 player_position;

    GameObject[] obstacles;
    int count;




    public float timer = 3f;
    float current_time;
    
    // Use this for initialization
    void Start()
    {
      player = GameObject.FindGameObjectWithTag("Player");


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

                 Instantiate(prefab, pos, Quaternion.identity);


                }

            }
            
        }
    }


