using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathScripting : MonoBehaviour {
    Renderer rend;
	// Use this for initialization
	void Start () {

        this.transform.SetParent(Camera.main.transform);
        this.transform.localPosition = new Vector3(0, 0, 10); //place ourselves in front of the camera

        rend = GetComponent<Renderer>();

        Callback.DoLerp((float l) => {
            MaterialPropertyBlock block = new MaterialPropertyBlock();
            block.SetFloat("_DistortionStrength", Mathf.Lerp(0.05f, 0, Mathf.Pow(l, 2)));
            rend.SetPropertyBlock(block);
        }, 5f, this).FollowedBy(() => UnityEngine.SceneManagement.SceneManager.LoadScene(3), this);
    }//UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex

    // Update is called once per frame
    void Update () {
		
	}
}
