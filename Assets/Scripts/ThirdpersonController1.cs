﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdpersonController1 : MonoBehaviour
{

    public Camera MyCamera;
    public float Speed = 2f;
    public float SprintSpeed = 5f;
    public float RotationSpeed = 15f;
    public float AnimationBlendSpeed = 2f;
    CharacterController MyController;
    Animator MyAnimator;

    float mDesiredRotation = 0f;
    float mDersiredAnimationSpeed = 0f;
    bool mSprinting = false;

    float mSpeedY = 0;
    float mGravity = -9.81f;
    void Start()
    {
        MyController = GetComponent<CharacterController>();
        MyAnimator = GetComponent<Animator>();
    }


    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        mSpeedY += mGravity * Time.deltaTime;
        mSprinting = Input.GetKey(KeyCode.LeftShift);
        Vector3 movement = new Vector3(x, 0, z);

        Vector3 rotatedMovement = Quaternion.Euler(0, MyCamera.transform.rotation.eulerAngles.y, 0) * movement;
        Vector3 verticalMovement = Vector3.up * mSpeedY;

        MyController.Move((verticalMovement + (rotatedMovement * (mSprinting ? SprintSpeed : Speed))) * Time.deltaTime);

        if (rotatedMovement.magnitude > 0)
        {
            mDesiredRotation = Mathf.Atan2(rotatedMovement.x, rotatedMovement.z) * Mathf.Rad2Deg;
            mDersiredAnimationSpeed = mSprinting ? 1 : .5f;
        }
        else
        {
            mDersiredAnimationSpeed = 1;
        }


        MyAnimator.SetFloat("Speed", Mathf.Lerp(MyAnimator.GetFloat("Speed"), mDersiredAnimationSpeed, AnimationBlendSpeed * Time.deltaTime)) ;

        Quaternion currentRotation = transform.rotation;
        Quaternion targetRotation = Quaternion.Euler(0, mDesiredRotation, 0);
        transform.rotation = Quaternion.Lerp(currentRotation, targetRotation, RotationSpeed * Time.deltaTime);

    }
}

