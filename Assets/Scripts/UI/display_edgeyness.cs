using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class display_edgeyness : MonoBehaviour {

    // ui script for displaying the amount of edgeyness

    // debugging
    public bool debug = false;
    public int edgeyness = 0;

    public bool isTemp = false;

    // pls insert this stuff in inspector
    //public GameObject player;
    public GameObject start; // obj w/ starting pos of bars
    public GameObject next;
    public GameObject bar; // prefab for the bar that appears as edgeyness
    //public GameObject display; 

    private Vector3 pos; // position of start, used for start pos of bars
    private Vector3 scale;
    private static int max_edgeyness = 100; // number of bars to instantiate
    private GameObject[] bar_array ; // array of bars :V
    private Text text_ref;
    private int mod = 5;

    private float offset = -20;

	// Use this for initialization
	void Start () {
        // set up text indicator for temp
        if (isTemp) 
        {
            var t = GameObject.Find("TempText");
            text_ref = t.GetComponent<Text>();
        }

        //player = GameObject.Find("Player");
        pos = start.transform.position;
        scale = start.transform.localScale;

        offset = next.transform.position.x - pos.x;

        // set up bar array
        if (!debug) 
        {
            if (!isTemp)
            {
                //max_edgeyness = PlayerEdgeyness.getMaxEdgeyness();
            }
            else { max_edgeyness = PlayerEdgeyness.getMaxTempEdgeyness(); }
        }
        bar_array = new GameObject[max_edgeyness];

        // instantiate bars
        for (int i = 0; i < max_edgeyness; i++)
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
	void Update () {
        // update max temp edgeyness
        if (!debug && isTemp) 
        {
            max_edgeyness = PlayerEdgeyness.getMaxTempEdgeyness();
        }

        // turn off all bars
        foreach (GameObject b in bar_array) 
        {
            b.SetActive(false);
            //b.transform.localScale = new Vector3(0, 0, 0);
        }

		// get edgeyness amount
        if (!debug)
        {
            if (!isTemp)
            {
                edgeyness = PlayerEdgeyness.getEdgeyness();
            }
            else {
                edgeyness = PlayerEdgeyness.getTempEdgeyness();
            }
        }

        // display temp as text above bars
        if (isTemp) 
        {
            if (edgeyness > 0) { text_ref.text = edgeyness + "/" + max_edgeyness; }
            else { text_ref.text = 0 + "/" + max_edgeyness; }
        }

        // turn on necessary bars
        if (isTemp)
        {
            float bars = edgeyness / mod;
            for (int i = 0; i < bars && i < max_edgeyness; i++)
            {
                bar_array[i].SetActive(true);
                //bar_array[i].transform.localScale = new Vector3(1, 1, 1);
            }
        }
        else 
        {
            for (int i = 0; i < edgeyness && i < max_edgeyness; i++)
            {
                bar_array[i].SetActive(true);
                //bar_array[i].transform.localScale = new Vector3(1, 1, 1);
            }
        }
	}
} //kmf
