using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class display_health : MonoBehaviour {

    // ui script for displaying the amount of edgeyness

    // debugging
    public bool debug = false;
    public float health = 0;

    //public bool isTemp = false;

    // pls insert this stuff in inspector
    public GameObject player;
    public GameObject start; // obj w/ starting pos of bars
    public GameObject next;
    public GameObject bar; // prefab for the bar that appears as edgeyness
    //public GameObject display; 

    private Vector3 pos; // position of start, used for start pos of bars
    private Vector3 scale;
    private static int max_health = 80; // number of bars to instantiate
    private GameObject[] bar_array; // array of bars :V

    private float offset = -20;

    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("Player");
        pos = start.transform.position;
        scale = start.transform.localScale;

        offset = next.transform.position.x - pos.x;

        // set up bar array
        if (!debug)
        {
            max_health = PlayerEdgeyness.getMaxTempEdgeyness();
        }
        bar_array = new GameObject[max_health];

        // instantiate bars
        for (int i = 0; i < max_health; i++)
        {
            // disp: x + (i * -10) <- adds offset to each bar pos so that they don't display on top of eachother
            Vector3 newpos = new Vector3(pos.x + (i * offset), pos.y, pos.z);
            GameObject newbar = Instantiate(bar, newpos, start.transform.rotation);
            newbar.transform.SetParent(this.gameObject.transform); // put them under the edgeyness obj
            newbar.transform.localScale = new Vector3(scale.x, scale.y, scale.z);
            newbar.SetActive(false); // make them all invisible
            //newbar.transform.localScale = new Vector3(0, 0, 0);
            bar_array[i] = newbar;

        }
    }

    // Update is called once per frame
    void Update()
    {
        // turn off all bars
        foreach (GameObject b in bar_array)
        {
            b.SetActive(false);
            //b.transform.localScale = new Vector3(0, 0, 0);
        }

        // get edgeyness amount
        if (!debug)
        {
            health = player.GetComponent<Health>().HealthValue;
        }
        // turn on necessary bars
        for (int i = 0; i < health && i < max_health; i++)
        {
            bar_array[i].SetActive(true);
            //bar_array[i].transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
