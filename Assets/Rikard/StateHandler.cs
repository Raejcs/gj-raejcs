using UnityEngine;
using System.Collections;

public class StateHandler : AbstractState {

	public bool isDeadly = false;

	void Start(){
		SetPropertiesByState ();
	}

	void Update () {
		SetPropertiesByState ();
	}

	void SetPropertiesByState(){
		MeshRenderer mr = GetComponent<MeshRenderer> ();
		Color c = mr.material.color;
		Color newColor = new Color(c.r,c.g,c.b,c.a);

		if(GetCurrentType() == type){
			newColor.a = .5f;
		} else {
			newColor.a = 1;
		}

		mr.material.color= newColor;
	}
}
