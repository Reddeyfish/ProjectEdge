using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class display_edgeyness : MonoBehaviour {

    public int edgeyness = 0;
    public GameObject player;
    public GameObject start;
    public GameObject bar;
    public GameObject display;

    private Vector3 pos;
    private static int max_edgeyness = 100;
    private GameObject[] bar_array = new GameObject[max_edgeyness];

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
        pos = start.transform.position;

        for (int i = 0; i < max_edgeyness; i++)
        {
            // disp: x + (i * -10)
            Vector3 newpos = new Vector3(pos.x + (i * -20), pos.y, pos.z);
            GameObject newbar = Instantiate(bar, newpos, start.transform.rotation);
            newbar.transform.SetParent(display.transform);
            newbar.SetActive(false);
            //newbar.transform.localScale = new Vector3(0, 0, 0);
            bar_array[i] = newbar;

        }
	}
	
	// Update is called once per frame
	void Update () {
        // turn off all bars
        foreach (GameObject b in bar_array) 
        {
            //b.transform.localScale = new Vector3(0, 0, 0);
            b.SetActive(false);
        }


		// get edgeyness amount
        // v uncomment this before using
        //edgeyness = player.GetComponent<PlayerEdgeyness>().getEdgeyness();

        // turn on bars

        for (int i = 0; i < edgeyness && i < max_edgeyness; i++) 
        {
            bar_array[i].SetActive(true);
            //bar_array[i].transform.localScale = new Vector3(1, 1, 1);
        }
	}
}
