using UnityEngine;
using System.Collections;

public class KillPlayer : MonoBehaviour {

	void Start () {
	
	}

	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Player")
			Global.restartCurrentScene ();
	}
}
