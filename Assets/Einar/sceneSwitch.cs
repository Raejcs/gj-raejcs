using UnityEngine;
using System.Collections;

public class sceneSwitch : MonoBehaviour
{
    
    void Start()
    {

    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Application.LoadLevel("cell1");
            
        }
               
    }
}
