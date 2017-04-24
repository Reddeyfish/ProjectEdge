using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadOnClick : MonoBehaviour
{

    //currently 0 is title , 1 is start, 2 is how to play, 3 is quit

    public void LoadScene(int scene)
    {
        SceneManager.LoadScene(scene);
    }
}