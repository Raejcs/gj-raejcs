﻿using UnityEngine;
using System.Collections;

public class StateHandler : MonoBehaviour {

	public SOType type = SOType.Red;
	private BaseSatate baseState = new BaseSatate();

	void Start(){
		baseState.type = type;
		SetPropertiesByState ();

		baseState.SetMaterialByType (GetComponent<MeshRenderer>());
	}

	void Update () {
		SetPropertiesByState ();
	}

	void SetPropertiesByState(){
		MeshRenderer mr = GetComponent<MeshRenderer> ();
		BoxCollider2D collider = GetComponent<BoxCollider2D> ();

		Color c = mr.material.color;
		Color newColor = new Color(c.r,c.g,c.b,c.a);

		if(baseState.GetCurrentType() != baseState.type){
			newColor.a = .5f;
			collider.isTrigger = true;
		} else {
			newColor.a = 1;
			collider.isTrigger = false;
		}

		mr.material.color= newColor;
	}
}
