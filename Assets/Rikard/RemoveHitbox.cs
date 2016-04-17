using UnityEngine;
using System.Collections;

public class RemoveHitbox : MonoBehaviour {

	public Hitbox hitbox = Hitbox.LEVEL1;
	public float levelSpeed = 0.03f;
	public float cameraY = 8f;

	// Use this for initialization
	void Start () {
		
	}

	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.tag == "Player") {
			setHitbox (false, hitbox);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
		
	}

	static string GetLevel(Hitbox hitbox){
		switch (hitbox) {
		case Hitbox.LEVEL1:
			return "Level1";
		case Hitbox.LEVEL2:
			return "Level2";
		case Hitbox.LEVEL3:
			return "Level3";
		case Hitbox.LEVEL4:
			return "Level4";
		default:
			return "";
		}
	}

	void setHitbox(bool state, Hitbox hitbox){
		var level = GetLevel (hitbox);
		var target = (GameObject) GameObject.FindWithTag (level);

		var col = target.GetComponent<Collider2D> ();
		var myCollider = GetComponent<Collider2D> ();

		if (col) {
			col.isTrigger = !state;
			myCollider.isTrigger = true;

			var mainCamera = (GameObject) GameObject.FindWithTag ("MainCamera");
			mainCamera.transform.position = new Vector3(mainCamera.transform.position.x,cameraY,mainCamera.transform.position.z);

		}
		
	}
}

public enum Hitbox {
	LEVEL1,
	LEVEL2,
	LEVEL3,
	LEVEL4
}