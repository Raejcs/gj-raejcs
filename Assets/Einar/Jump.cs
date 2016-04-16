using UnityEngine;
using System.Collections;

public class Jump : MonoBehaviour {


    public bool grounded = true;
    public float jumpPower = 190;


	void Start () {


	
	}
	
	void Update ()
    {
        Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();

        if (!grounded && rigidbody.velocity.y == 0)
        {
            grounded = true;
        }

        if (Input.GetKeyDown(KeyCode.Space) && grounded == true)
        {
            rigidbody.AddForce(transform.up * jumpPower);
            grounded = false;
        }

       
	}
}
