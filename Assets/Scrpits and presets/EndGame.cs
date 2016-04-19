using UnityEngine;
using System.Collections;

public class EndGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        Invoke("end", 9);

    }

    void end() {
        Application.Quit();
        Debug.Log("End the game");
    }
}
