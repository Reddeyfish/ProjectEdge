using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailSpawn : MonoBehaviour {

    public GameObject quotes;

    GameObject player;
    Vector3 player_position;



    public float timer = 3f;
    float current_time;
    // Use this for initialization
    void Start () {

        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        player_position = new Vector3(player.transform.position.x, player.transform.position.y, 0);
        spawn_text();
    }
    void spawn_text()
    {
            if (current_time < timer)
            {
                current_time += Time.deltaTime;
            }

            else
            {
                current_time = 0;
                //Debug.Log("Too Little,Spawn more edge.");
                Vector3 pos = new Vector3(player_position.x,player_position.y, 0);

                Instantiate(quotes, pos, Quaternion.identity);


            }

        }
    }
