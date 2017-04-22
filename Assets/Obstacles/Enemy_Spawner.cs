using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spawner : MonoBehaviour {

    public GameObject prefab;
    GameObject player;
    public int numberOfObjects = 20;
    public float radius = 10f;
    Vector3 player_position;
    // Use this for initialization
    void Start()
    {
      player = GameObject.FindGameObjectWithTag("Player");


    }
   
    // Update is called once per frame
    void Update()
    {
        GameObject[] obstacles = GameObject.FindGameObjectsWithTag("Obstacle");
        int count = obstacles.Length;

        player_position = new Vector3(player.transform.position.x, player.transform.position.y, 0);



        if (count < numberOfObjects)
        {
            Debug.Log("Too Little,Spawn more edge.");
            for (int i = 0; i <= numberOfObjects; i++)
                
            {
                Vector3 pos = new Vector3(Random.Range(player_position.x - radius, player_position.x + radius),
                    Random.Range(player_position.y - radius, player_position.y + radius), 0);
                Instantiate(prefab, pos, Quaternion.identity);
            }
        }
        
    }
}
