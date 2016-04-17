using UnityEngine;
using System.Collections;

public class Jump : MonoBehaviour {
    public float jumpPower = 400;
    public bool dubbleJumpFix = true;
    int jumpCount = 0;

	Rigidbody2D rigidbody;
	BoxCollider2D collider;

    void Start () {
		rigidbody = GetComponent<Rigidbody2D>();
		collider = GetComponent<BoxCollider2D> ();
	}

	bool IsGrounded() {
		Vector2 btm = new Vector2 (collider.bounds.center.x, collider.bounds.center.y - collider.bounds.extents.y-.01f);

		RaycastHit2D cast = Physics2D.Raycast (btm, Vector2.down);
		float dist = cast.fraction;
		return dist < .1f && !cast.collider.isTrigger;
	}
	
	void Update ()
    {

		if (Input.GetKeyDown (KeyCode.Space)) {
			bool grounded = IsGrounded ();

			if (grounded) {
				jumpCount = 0;
			}

			if (grounded || jumpCount < 2) {
				rigidbody.velocity = Vector2.zero;
				rigidbody.AddForce (transform.up * jumpPower);
				jumpCount++;
			}
		}
	}
}
