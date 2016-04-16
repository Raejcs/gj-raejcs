using UnityEngine;
using System.Collections;

public class Jump : MonoBehaviour {
    public float jumpPower = 400;
	//private bool isGrounded = false;

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

		if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            rigidbody.AddForce(transform.up * jumpPower);
        }
	}
}
