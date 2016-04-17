using UnityEngine;
using System.Collections;

public class Jump : MonoBehaviour {
    public float jumpPower = 400;
    int jumpCount = 0;

    void Start () {
	}

	bool IsGrounded() {
		BoxCollider2D collider = GetComponent<BoxCollider2D> ();
		Vector2 btm = new Vector2 (collider.bounds.center.x, collider.bounds.center.y - collider.bounds.extents.y-.01f);

		RaycastHit2D cast = Physics2D.Raycast (btm, Vector2.down);
		float dist = cast.fraction;
		return dist < .1f && !cast.collider.isTrigger;

	}
	
	void Update ()
    {
        Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();

		if (Input.GetKeyDown(KeyCode.Space) && IsGrounded() || Input.GetKeyDown(KeyCode.Space) && jumpCount == 1)
        {

            if (jumpCount == 1)
            {
                rigidbody.velocity = Vector2.zero;
                rigidbody.AddForce(transform.up * jumpPower);
            }
            else
            {
                rigidbody.AddForce(transform.up * jumpPower);
            }
            

            jumpCount += 1;

            if (jumpCount == 2) { jumpCount = 0; }

            Debug.Log(jumpCount);
            Debug.Log("jump");
        }
        

	}
}
