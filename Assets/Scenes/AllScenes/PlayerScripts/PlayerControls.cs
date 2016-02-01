﻿using UnityEngine;
using System.Collections;

public class PlayerControls : MonoBehaviour {

    private Transform myTransform;
    private Transform cameraTransform;
    private bool isGrounded = false;
    private Vector3 gravity = new Vector3(0, -5, 0);
    private Vector3 jumpVelocity;
    private bool jumping = false;   //ako igrac zeli skociti (znaci da ne pada)

    public float rotationSpeed = 500;

    private Player playerStats;

	void Start () {
        myTransform = GetComponent<Transform>();
        cameraTransform = Camera.main.transform;
	}
	
	void Update () {
        PlayerMovement();
	}

    private void PlayerMovement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            myTransform.position += myTransform.forward * Time.deltaTime * CurrentPlayer.currentPlayer.MoveSpeed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            myTransform.position -= myTransform.forward * Time.deltaTime * CurrentPlayer.currentPlayer.MoveSpeed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            myTransform.Rotate(0, -100 * Time.deltaTime, 0, Space.Self);
        }
        if (Input.GetKey(KeyCode.D))
        {
            myTransform.Rotate(0, 100 * Time.deltaTime, 0, Space.Self);
        }
        if (Input.GetKey(KeyCode.Space) && isGrounded == true)
        {
            isGrounded = false;
            jumping = true;
            jumpVelocity = new Vector3(0, CurrentPlayer.currentPlayer.JumpForce, 0);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            myTransform.position -= myTransform.right * Time.deltaTime * CurrentPlayer.currentPlayer.MoveSpeed;
        }
        if (Input.GetKey(KeyCode.E))
        {
            myTransform.position += myTransform.right * Time.deltaTime * CurrentPlayer.currentPlayer.MoveSpeed;
        }

        if (isGrounded == false)
        {
            myTransform.position = myTransform.position + Time.deltaTime * jumpVelocity;
            jumpVelocity = jumpVelocity + Time.deltaTime * gravity * 2;
        }

        if (Input.GetKey(KeyCode.Mouse0) && (Input.GetAxis("Mouse X") != 0f || Input.GetAxis("Mouse Y") != 0f)) //move camera around
        {
            float rotX = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
            Camera.main.transform.RotateAround(myTransform.position, Vector3.up, rotX);

            float rotY = Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;
            cameraTransform.RotateAround(myTransform.position, Vector3.left, rotY);

            cameraTransform.rotation = Quaternion.Euler(cameraTransform.rotation.eulerAngles.x, cameraTransform.rotation.eulerAngles.y, 0);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        isGrounded = true;
        jumping = false;
    }

    void OnCollisionExit(Collision other)
    {
        if (other.collider.tag == "Floor")
        {
            if (!jumping)
            {
                isGrounded = false;
                jumpVelocity = new Vector3(0, 0.01f, 0);
            }
        }
    }


}