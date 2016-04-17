using UnityEngine;
using System.Collections;

public class RotateWorld : MonoBehaviour {
	public float rotationSpeed = 0.03f;
    bool inGame;
	// Use this for initialization
	void Start () {
		Global.rotationSpeed = rotationSpeed;
        inGame = false;
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)) { inGame = true; }

            if(inGame)
            { RotateStep(); }
            
	}

	void RotateStep(){
		float delta = 60 / Time.deltaTime;
		float rotation = delta * .001f * Global.rotationSpeed;
		// Rotate the object around its local Y axis at 1 degree per second
		transform.RotateAround(transform.position, Vector3.forward, rotation);
	}
}
