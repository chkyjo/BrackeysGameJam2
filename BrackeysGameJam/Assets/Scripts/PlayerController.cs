﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour{

    public GameManager gameManager;
    public Transform mainCameraTransform;

    public Rigidbody rb;

    public int walkSpeed;
    public int runSpeed;

    public float lookSensitivity = 5;
    float yaw = 0; //y rotation
    float pitch = 0; //x rotation

    int interactRange = 10;
    LayerMask layerMask;

    private void Start() {
        layerMask = LayerMask.GetMask("Item");
    }

    // Update is called once per frame
    void FixedUpdate(){
        Move();

        RaycastHit hit;
        if(Physics.Raycast(mainCameraTransform.position, mainCameraTransform.forward, out hit, interactRange, layerMask)) {
            //enable UI
            gameManager.EnableInteractUI();
        }
        else {
            //enable UI
            gameManager.DisableInteractUI();
        }
    }

    private void Move() {

        //rotate the camera based on mouse position
        RotateCamera();

        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        Vector3 leftRight = moveX * mainCameraTransform.right;
        leftRight.y = 0;
        Vector3 forwardBack = moveY * mainCameraTransform.forward;
        forwardBack.y = 0;

        Vector3 direction = (leftRight + forwardBack).normalized;

        Vector3 velocity = direction * walkSpeed;

        if(velocity != Vector3.zero) {
            rb.MovePosition(transform.position + velocity * Time.deltaTime);
        }

    }

    //lock the y rotation of the player
    private void LateUpdate() {
        transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y, 0);
    }

    void RotateCamera() {
        pitch += Input.GetAxis("Mouse Y") * lookSensitivity;
        pitch = Mathf.Clamp(pitch, -45, 45);

        //x rotation of camera
        mainCameraTransform.localEulerAngles = new Vector3(-pitch, 0, 0);

        //y rotation of body
        transform.Rotate(0, Input.GetAxis("Mouse X") * lookSensitivity, 0);

    }

    public void OnTriggerEnter(Collider other) {
        ItemPickUp itemPU = other.GetComponent<ItemPickUp>();
        if (itemPU != null) {
            Debug.Log("Found item");
            itemPU.PickUpItem();
        }
    }
}