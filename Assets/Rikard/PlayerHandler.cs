using UnityEngine;
using System.Collections;

public class PlayerHandler : MonoBehaviour {
	
	private BaseSatate baseState = new BaseSatate();
	public float killQuote = 0.7f;

	void Start(){
		baseState.type = Global.type;
		baseState.SetMaterialByType(GetComponent<MeshRenderer>());
	}

	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.tag != "Ground") {

			var p = transform.position;
			var p2 = coll.gameObject.transform.position;

			Vector3 b2 = coll.gameObject.GetComponent<Collider2D> ().bounds.extents;

			Vector3 dp = p - p2;

			dp.y *= b2.x / b2.y;

			var ang = Mathf.Abs (Mathf.Atan (dp.y / dp.x));

			if (ang < killQuote) {
				Global.restartCurrentScene ();
			}
		}
	}

	void Update () {
		if (Input.GetKeyDown (KeyCode.S)|| Input.GetKeyDown(KeyCode.DownArrow)) {
			Global.type = GetNextType ();
			baseState.type = Global.type;
			baseState.SetMaterialByType (GetComponent<MeshRenderer>());

			var as1 = GameObject.Find("Audio1").GetComponent<AudioSource>();
			var as2 = GameObject.Find("Audio2").GetComponent<AudioSource>();
			var asSwap = GameObject.Find("AudioSwap").GetComponent<AudioSource>();
			asSwap.Play ();

			switch (baseState.type) {
			case SOType.Blue:
				as1.mute = true;
				as2.mute = false;
				break;
			case SOType.Red:
				as1.mute = false;
				as2.mute = true;
				break;
			}
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
