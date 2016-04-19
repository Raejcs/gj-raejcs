using UnityEngine;
using System.Collections;

public class Jump : MonoBehaviour {
    public float jumpPower = 400;
    int jumpCount = 0;

	Rigidbody2D rigidbody;
	BoxCollider2D collider;
	AudioSource jumpAudioSource; 
    public AudioSource jumpAudioSource1;
    public AudioSource jumpAudioSource2;
    public AudioSource jumpAudioSource3;
    public AudioSource jumpAudioSource4;
    public AudioSource jumpAudioSource5;
    public AudioSource jumpAudioSource6;
    public AudioSource jumpAudioSource7;

    public AudioSource jumpShortAudioSource1;
    public AudioSource jumpShortAudioSource2;
    public AudioSource jumpShortAudioSource3;
    public AudioSource jumpShortAudioSource4;

    void Start () {
		rigidbody = GetComponent<Rigidbody2D>();
		collider = GetComponent<BoxCollider2D> ();
		jumpAudioSource = GetComponent<AudioSource>();
	}

	bool IsGrounded() {
		Vector2 btm = new Vector2 (collider.bounds.center.x, collider.bounds.center.y - collider.bounds.extents.y-.01f);

		RaycastHit2D cast = Physics2D.Raycast (btm, Vector2.down);
		float dist = cast.fraction;
		if (cast.collider != null) {
			return dist < .1f;// && !cast.collider.isTrigger;
		} else {
			return false;
		}
	}
	
	void Update ()
    {
        bool grounded = IsGrounded();
        Global.playerIsGrounded = grounded;

		if (Input.GetKeyDown (KeyCode.Space)|| Input.GetKeyDown(KeyCode.UpArrow)|| Input.GetMouseButtonDown(0)) {

			if (grounded) {
				jumpCount = 0;

                //PlayLandSound
                playShortJumpSound();

            }

			if (grounded || jumpCount < 2) {
				rigidbody.velocity = Vector2.zero;
				rigidbody.AddForce (transform.up * jumpPower);

				jumpCount++;

				//if (jumpAudioSource != null) {

                    if (jumpCount == 1) { playJumpSound(); }
                    if (jumpCount == 2) { playShortJumpSound(); }

                // }
            }
		}
	}


    void playJumpSound() {

        switch (Random.Range(1, 7))
        {
            case (1): jumpAudioSource1.Play(); break;
            case (2): jumpAudioSource2.Play(); break;
            case (3): jumpAudioSource3.Play(); break;
            case (4): jumpAudioSource4.Play(); break;
            case (5): jumpAudioSource5.Play(); break;
            case (6): jumpAudioSource6.Play(); break;
            case (7): jumpAudioSource7.Play(); break;

        }

    }

    void playShortJumpSound()
    {

        switch (Random.Range(1, 4))
        {
            case (1): jumpShortAudioSource1.Play(); break;
            case (2): jumpShortAudioSource2.Play(); break;
            case (3): jumpShortAudioSource3.Play(); break;
            case (4): jumpShortAudioSource4.Play(); break;


        }

    }

}
