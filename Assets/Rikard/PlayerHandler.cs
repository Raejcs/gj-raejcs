using UnityEngine;
using System.Collections;

public class PlayerHandler : MonoBehaviour {
	
	private BaseSatate baseState = new BaseSatate();

	void Start(){
		baseState.type = Global.type;
		baseState.SetMaterialByType(GetComponent<MeshRenderer>());
	}

	void Update () {
		if (Input.GetKeyDown (KeyCode.S)) {
			Global.type = GetNextType ();
			baseState.type = Global.type;
			baseState.SetMaterialByType (GetComponent<MeshRenderer>());
		}

		Global.rotationSpeed = 1 / (transform.position.y / 8f);

		Debug.Log (Global.rotationSpeed);

		// Camera follow
		var mainCamera = (GameObject) GameObject.FindWithTag ("MainCamera");
		mainCamera.transform.position = new Vector3(transform.position.x,transform.position.y,transform.position.z- 10);
	}

	SOType GetNextType(){
		switch (baseState.type) {
		case SOType.Blue:
			return SOType.Red;
		case SOType.Red:
			return SOType.Blue;
		default:
			return SOType.Red;
		}
	}
}
