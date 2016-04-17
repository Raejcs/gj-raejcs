using UnityEngine;
using System.Collections;

public class PlayerHandler : MonoBehaviour {
	
	private BaseSatate baseState = new BaseSatate();

	void Start(){
		baseState.type = Global.type;
		baseState.SetMaterialByType(GetComponent<MeshRenderer>());
	}

	void OnCollisionEnter2D(Collision2D coll){
		var p = transform.position;
		var p2 = coll.gameObject.transform.position;
		var dp = p - p2;

		var ang = Mathf.Abs(Mathf.Atan (dp.y / dp.x));

		if (ang < 0.9) {
			Global.restartCurrentScene ();
		}
	}

	void Update () {
		if (Input.GetKeyDown (KeyCode.S)) {
			Global.type = GetNextType ();
			baseState.type = Global.type;
			baseState.SetMaterialByType (GetComponent<MeshRenderer>());
		}
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
