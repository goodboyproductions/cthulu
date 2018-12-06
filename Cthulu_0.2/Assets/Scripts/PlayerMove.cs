﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    public float speed;
    public float speedh;
    public float speedV = 4.0f;
    //public float speedv;
    public Rigidbody rb;

    private float yaw = 0.0f;
    private float pitch = 0.0f;
    // Use this for initialization
    private float vertical;
    private float horizontal;
    public Camera cam;
    public CursorLockMode wantedMode;
    //public Cursor cur;
    void Start () {
        rb = GetComponent<Rigidbody>();
        Cursor.visible = false;
        Cursor.lockState = wantedMode;
    }   
	
	// Update is called once per frame
	void FixedUpdate () {


        //float mouseX = (Input.mousePosition.x / Screen.width) - 0.5f;
        float mouseY = (Input.mousePosition.y / Screen.height) - 0.5f;
        //transform.rotation = Quaternion.Euler(new Vector4(-1f , mouseX * 360f, transform.rotation.z));
        //cam.transform.localRotation = Quaternion.Euler(new Vector4(-1f * (mouseY * 60f),0f, transform.localRotation.z));
        //print(Quaternion.Euler(new Vector4(-1f, 0f, transform.rotation.z)).y);
        /* move objects */
        //transform.LookAt(Input.mousePosition);
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");
        rb.AddForce((transform.forward * vertical) * speed );
        rb.AddForce((transform.right * horizontal) * speed);

        yaw += speedh * Input.GetAxis("Mouse X");
        pitch -= speedV * Input.GetAxis("Mouse Y");
        //print(pitch);
        if (Mathf.Abs(pitch) < 80 ) {
            cam.transform.eulerAngles = new Vector3(pitch, cam.transform.eulerAngles.y, 0.0f);
        }
        transform.eulerAngles = new Vector3(transform.transform.eulerAngles.x, yaw,0.0f);

    }

}
