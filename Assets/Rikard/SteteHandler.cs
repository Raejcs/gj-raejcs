using UnityEngine;
using System.Collections;

public class SteteHandler : MonoBehaviour {

	public SOType type = SOType.Red;
	public bool isDeadly = false;
	public bool isPlayer = false;

	private static Material blue = Resources.Load ("BlueSO", typeof(Material)) as Material;
	private static Material red = Resources.Load ("RedSO", typeof(Material)) as Material;

	// Use this for initialization
	void Start () {
		MeshRenderer mr = GetComponent<MeshRenderer> ();

		switch (type) {
		case SOType.Blue:
			mr.material = blue;
			break;
		case SOType.Red:
			mr.material = red;
			break;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (!isPlayer) {
			SetPropertiesByState ();
		}
	}


	SOType GetCurrentType(){
		return Global.type;
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
