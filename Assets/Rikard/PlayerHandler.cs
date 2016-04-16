using UnityEngine;
using System.Collections;

public class SteteHandler : AbstractState {

	public KeyCode toggleKey = KeyCode.S;

	void Update () {
		type = Global.type;

		if (Input.GetKeyDown (toggleKey)) {
			Global.type = GetNextType ();
			SetMaterialByType ();
		}
	}

	SOType GetNextType(){
		switch (type) {
		case SOType.Blue:
			return SOType.Red;
		case SOType.Red:
			return SOType.Blue;
		default:
			return SOType.Red;
		}
	}
}
