﻿using UnityEngine;
using System.Collections;

public class RemoveHitbox : MonoBehaviour {

	public Hitbox hitbox = Hitbox.LEVEL1;
	public float levelSpeed = 0.03f;
	public float cameraY = 8f;

	public float cameraSpeed = 30.0F;
	private float startTime;
	private float journeyLength;
	private Vector3 startTransition;
	private Vector3 endTransition;
	private bool transitioning = false;

	// Use this for initialization
	void Start () {
		
	}

	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.tag == "Player") {
			setHitbox (false, hitbox);
			var mainCamera = (GameObject) GameObject.FindWithTag ("MainCamera");

			transitioning = true;
			startTime = Time.time;
			journeyLength = mainCamera.transform.position.y - cameraY;
			startTransition = mainCamera.transform.position;
			endTransition = new Vector3 (startTransition.x, cameraY, startTransition.z);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (transitioning) {
			float distCovered = (Time.time - startTime) * cameraSpeed;
			float fracJourney = distCovered / journeyLength;

			var mainCamera = (GameObject) GameObject.FindWithTag ("MainCamera");
			mainCamera.transform.position = Vector3.Lerp (startTransition, endTransition, fracJourney);

			Debug.Log (fracJourney);

			if (fracJourney > 1) {
				transitioning = false;
			}
		}
		
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
		var targets = (GameObject[]) GameObject.FindGameObjectsWithTag (level);

		foreach(var target in targets){
			if(target != null){
				var col = target.GetComponent<Collider2D> ();
				var myCollider = GetComponent<Collider2D> ();

				if (col) {
					col.isTrigger = !state;
					myCollider.isTrigger = true;
				}
			}
		}
	}
}

public enum Hitbox {
	LEVEL1,
	LEVEL2,
	LEVEL3,
	LEVEL4
}