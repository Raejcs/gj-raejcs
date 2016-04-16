using UnityEngine;
using System.Collections;

public abstract class AbstractState : MonoBehaviour {

	public SOType type = SOType.Red;

	private static Material blue = Resources.Load ("BlueSO", typeof(Material)) as Material;
	private static Material red = Resources.Load ("RedSO", typeof(Material)) as Material;

	// Use this for initialization
	void Start () {
		SetMaterialByType();
	}

	void Update () {
		
	}

	public void SetMaterialByType(){
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
		
		
	public SOType GetCurrentType(){
		return Global.type;
	}
}
