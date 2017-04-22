using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEdgeyness : MonoBehaviour {

    private static int edgeyness;
    private static int temporaryEdgeyness;

	// Use this for initialization
	void Start () {
        StartCoroutine(testPrint());
	}

    private IEnumerator testPrint() {
        while (true) {
            print("Edgeyness: " + getEdgeyness());
            print("Temp Edgyness: " + getTempEdgeyness());

            yield return new WaitForSeconds(1);
        }
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

    public void resetTempEdgeyness() {
        temporaryEdgeyness = 0;
    }
    public void changeTempEdgeynessBy(int changeNum) {
        temporaryEdgeyness += changeNum;
    }
    public void setTempEdgeyness(int newEdgeyness) {
        temporaryEdgeyness = newEdgeyness;
    }
    public int getTempEdgeyness() {
        return temporaryEdgeyness;
    }

    public void transferEdgeyness() {
        changeEdgeynessBy(getTempEdgeyness());
        resetTempEdgeyness();
    }
}
