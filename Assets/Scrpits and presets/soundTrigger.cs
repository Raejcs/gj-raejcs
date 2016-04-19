using UnityEngine;
using System.Collections;

public class soundTrigger : MonoBehaviour {

    AudioSource AudioSource;

    void Start()
    {
        AudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {


    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Player")
        {
            AudioSource.Play();

        }
    }

}
