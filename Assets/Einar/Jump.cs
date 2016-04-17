using UnityEngine;
using System.Collections;

public class Jump : MonoBehaviour {
    public float jumpPower = 400;
    int jumpCount = 0;

	Rigidbody2D rigidbody;
	BoxCollider2D collider;
	AudioSource jumpAudioSource; 

    void Start () {
		rigidbody = GetComponent<Rigidbody2D>();
		collider = GetComponent<BoxCollider2D> ();
		jumpAudioSource = GetComponent<AudioSource>();
	}

	bool IsGrounded() {
		Vector2 btm = new Vector2 (collider.bounds.center.x, collider.bounds.center.y - collider.bounds.extents.y-.01f);

		RaycastHit2D cast = Physics2D.Raycast (btm, Vector2.down);
		float dist = cast.fraction;
		return dist < .1f && !cast.collider.isTrigger;
	}
	
	void Update ()
    {
        bool grounded = IsGrounded();
        Global.playerIsGrounded = grounded;

		if (Input.GetKeyDown (KeyCode.Space)) {

			if (grounded) {
				jumpCount = 0;
			}

			if (grounded || jumpCount < 2) {
				rigidbody.velocity = Vector2.zero;
				rigidbody.AddForce (transform.up * jumpPower);

				jumpCount++;

				if (jumpAudioSource != null) {
					jumpAudioSource.Play ();
				}
			}
		}
	}
}
