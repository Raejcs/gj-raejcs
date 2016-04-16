using UnityEngine;
using System.Collections;

public class BaseSatate {

	public SOType type = SOType.Red;

	private static Material blue = Resources.Load ("BlueSO", typeof(Material)) as Material;
	private static Material red = Resources.Load ("RedSO", typeof(Material)) as Material;

	public void SetMaterialByType(MeshRenderer mr){

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
