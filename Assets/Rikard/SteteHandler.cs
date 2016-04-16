using UnityEngine;
using System.Collections;

public class SteteHandler : MonoBehaviour {

	public int myState = 0;

	private static Material opaque = Resources.Load ("OpaqueSO", typeof(Material)) as Material;
	private static Material transparent = Resources.Load ("TransparentSO", typeof(Material)) as Material;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		SetPropertiesByState ();
	}

	int GetState(){
		return Global.state;
	}

	void SetPropertiesByState(){
		MeshRenderer mr = GetComponent<MeshRenderer> ();
		switch (GetState()) {
		case myState:
			mr.material = transparent;
			break;
		default:
			mr.material = opaque;
			break;
		}
	}
}
