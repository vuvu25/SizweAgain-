using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //Making Camera Follow
    
    public Transform target;

    void Start()
    {
        
    }

    
    void LateUpdate()
    {
        transform.position = target.position; 
    }
}
