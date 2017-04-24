using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public GameObject alert;
    public GameObject healthText;
    //public GameObject display; 

    private Vector3 pos; // position of start, used for start pos of bars
    private Vector3 scale;
    private float max_health = 80; // number of bars to instantiate
    private GameObject[] bar_array; // array of bars :V
    private int mod = 5;
    private Text text_ref;

    private float offset; //= -20;
    private float timer = 1.0f;

    // Use this for initialization
    void Start()
    {
        //player = GameObject.Find("Player");
        text_ref = healthText.GetComponent<Text>();

        pos = start.transform.position;
        scale = start.transform.localScale;

        offset = next.transform.position.x - pos.x;

        // set up bar array
        if (!debug)
        {
            max_health = player.GetComponent<Health>().MaxHealth;
        }
        bar_array = new GameObject[(int)max_health];

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
        // update max health
        if (!debug)
        {
            max_health = player.GetComponent<Health>().MaxHealth;
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
            health = player.GetComponent<Health>().HealthValue;
        }
        // calc amount of bars
        float bars = health / mod;

        // visual alert when health is low
        if (bars <= 7)
        {
            timer -= 1 * Time.deltaTime;
            if (timer <= 0)
            {
                if (alert.activeSelf) { alert.SetActive(false); }
                else { alert.SetActive(true); }
                timer = 1.0f;
            }
        }
        else 
        { 
            timer = 1.0f;
            alert.SetActive(false);
        }

        // display health as text above bars
        if (health > 0) { text_ref.text = "Health: " + (int)health + "/" + (max_health); }
        else { text_ref.text = "Health: " + 0 + "/" + (max_health); }

        // turn on necessary bars
        for (int i = 0; i < bars && i < max_health; i++)
        {
            bar_array[i].SetActive(true);
            //bar_array[i].transform.localScale = new Vector3(1, 1, 1);
        }

        
    }
} //kmf
