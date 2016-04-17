using UnityEngine;
using System.Collections;

public class rotate : MonoBehaviour
{


    public float rotationx;
    public float rotationy;
    public float rotationz;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Global.playerIsGrounded)
        {
            gameObject.transform.Rotate(rotationx, rotationy, rotationz);
        }
    }
}
