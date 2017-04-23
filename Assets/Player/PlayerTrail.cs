using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.IO;

public class PlayerTrail : MonoBehaviour {

    public TextAsset text;
    List<string> trails;

    public float movement_speed = 10f;

    public float timer = 5f;
    float time = 0;
    // Use this for initialization
    void Start () {//text things
        trails = new List<string>();
        StringReader reader = new StringReader(text.text);
        if (reader != null)
        {
            string line = reader.ReadLine();
            string[]quotes = line.Split(';');
            for (int i = 0; i != quotes.Length - 1; i++)
                trails.Add(quotes[i]);
           
        }

        this.GetComponent<TextMesh>().text = trails[Random.Range(0, trails.Count)];
        this.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-3, 3), Random.Range(-3, 3)) * movement_speed);
    }
	

	// Update is called once per frame
	void Update () {

        if (time < timer)
        {
            time += Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }



    }

   
}
