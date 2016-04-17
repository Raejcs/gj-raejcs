using UnityEngine;
using System.Collections;

public class Jump : MonoBehaviour {
    public float jumpPower = 400;
    public bool dubbleJumpFix = true;
    int jumpCount = 0;

    public AudioClip Mario_Jumping;
    float vol = 1.0f;

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
        AudioSource source = GetComponent<AudioSource>();

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded() || Input.GetKeyDown(KeyCode.Space) && jumpCount == 1)
        {

            if (dubbleJumpFix)
            {

                if (jumpCount == 1)
                {
                    rigidbody.velocity = Vector2.zero;
                    rigidbody.AddForce(transform.up * jumpPower);

                    //source.PlayOneShot(Mario_Jumping, vol);
                    source.Play();
                }
                else
                {
                    rigidbody.AddForce(transform.up * jumpPower);

                    //source.PlayOneShot(Mario_Jumping, vol);
                    source.Play();
                }
            }

            else
            {
                rigidbody.AddForce(transform.up * jumpPower);

                //source.PlayOneShot(Mario_Jumping, vol);
                source.Play();
            }

            jumpCount += 1;

            if (jumpCount == 2) { jumpCount = 0; }

            Debug.Log(jumpCount);
            Debug.Log("jump");
        }
        

	}
}
