using UnityEngine;
using System.Collections;

public class EnterCore : MonoBehaviour {

   

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	

	}

    void OnTrigger2DEnter(Collision2D coll)
    {

        Debug.Log("enter core");

        if (coll.gameObject.tag == "Player")
        {


            Application.LoadLevelAdditive(1);

        }
    }

}
