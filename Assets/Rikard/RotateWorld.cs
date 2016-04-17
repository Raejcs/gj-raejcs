using UnityEngine;
using System.Collections;

public class RotateWorld : MonoBehaviour {
	public static float rotationSpeed = 0.03f;

	// Use this for initialization
	void Start () {
		Global.rotationSpeed = rotationSpeed;
	}
	
	// Update is called once per frame
	void Update () {
		RotateStep();
	}

	void RotateStep(){
		float delta = 60 / Time.deltaTime;
		float rotation = delta * .001f * Global.rotationSpeed;
		// Rotate the object around its local Y axis at 1 degree per second
		transform.RotateAround(transform.position, Vector3.forward, rotation);
	}
}
