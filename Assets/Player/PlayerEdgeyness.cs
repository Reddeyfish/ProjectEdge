using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEdgeyness : MonoBehaviour {

    private int edgeyness;

	// Use this for initialization
	void Start () {
		
	}
	
    public void resetEdgeyness() {
        edgeyness = 0;
    }
    public void changeEdgeynessBy(int changeNum) {
        edgeyness += changeNum;
    }
    public void setEdgeyness(int newEdgeyness) {
        edgeyness = newEdgeyness;
    }
    public int getEdgeyness() {
        return edgeyness;
    }

}
