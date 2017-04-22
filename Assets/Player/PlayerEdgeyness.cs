using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEdgeyness : MonoBehaviour {

    private static int edgeyness;
    private static int temporaryEdgeyness;
    private static int maxTempEdgeyness = 50;

    public delegate void OnEdgeynessChange();

    public static event OnEdgeynessChange onEdgeynessChange = delegate { };

	// Use this for initialization
	void Start () {
        //StartCoroutine(testPrint());
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
        onEdgeynessChange();
    }
    public static void changeEdgeynessBy(int changeNum) {
        edgeyness += changeNum;
        onEdgeynessChange();
    }
    public void setEdgeyness(int newEdgeyness) {
        edgeyness = newEdgeyness;
        onEdgeynessChange();
    }
    public static int getEdgeyness() {
        return edgeyness;
    }

    public void resetTempEdgeyness() {
        temporaryEdgeyness = 0;
    }
    public void changeTempEdgeynessBy(int changeNum) {
        temporaryEdgeyness += changeNum;
        if (temporaryEdgeyness > maxTempEdgeyness) { edgeyness = maxTempEdgeyness; }
    }
    public void setTempEdgeyness(int newEdgeyness) {
        temporaryEdgeyness = newEdgeyness;
        if (temporaryEdgeyness > maxTempEdgeyness) { edgeyness = maxTempEdgeyness; }
    }
    public int getTempEdgeyness() {
        return temporaryEdgeyness;
    }

    public void transferEdgeyness() {
        changeEdgeynessBy(getTempEdgeyness());
        resetTempEdgeyness();
    }

        return maxTempEdgeyness;
    }

        maxTempEdgeyness = newMax;
        if (temporaryEdgeyness > maxTempEdgeyness) { edgeyness = maxTempEdgeyness; }
    }
}
