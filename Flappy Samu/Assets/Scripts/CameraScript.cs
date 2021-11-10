using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform targetBird;
    
    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = new Vector3(targetBird.position.x,
                                          transform.position.y,
                                          transform.position.z);  
    }
}
