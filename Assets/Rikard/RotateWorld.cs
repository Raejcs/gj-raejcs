using UnityEngine;
using System.Collections;

public class RotateWorld : MonoBehaviour {

	public float rotationSpeed = 1;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		RotateStep();
	}

	void RotateStep(){
		float delta = 60 / Time.deltaTime;
		float rotation = delta * rotationSpeed * .001f;
		// Rotate the object around its local Y axis at 1 degree per second
		transform.RotateAround(transform.position, Vector3.forward, rotation);
	}
}
