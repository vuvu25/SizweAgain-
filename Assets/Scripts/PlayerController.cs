﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed;
    public CharacterController charCon;

    private Vector3 moveInput;

    public Transform camTrans;
    public float mouseSensitivity;
    public bool invertX;
    public bool invertY;
    void Start()
    {
        
    }

    
    void Update()
    {
        //moveInput.x = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        //moveInput.z = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        Vector3 vertMove = transform.forward * Input.GetAxis("Vertical");

        moveInput = vertMove * Time.deltaTime;



        charCon.Move(moveInput);

        charCon.Move(moveInput);

        //control camera rotation
        Vector2 mouseInput = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y")) * mouseSensitivity;
        
        if(invertX)
        {
            mouseInput.x = mouseInput.x;
        }
        if (invertY) 
        {
            mouseInput.y = -mouseInput.y;
        }
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + mouseInput.x, transform.rotation.eulerAngles.z);

        camTrans.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(-mouseInput.y, 0f, 0f));


    }
}
