using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WipePlayerPrefs : MonoBehaviour {
    
    public void ButtonWipePlayerPrefs() {
        PlayerPrefs.DeleteAll();
    }

}
