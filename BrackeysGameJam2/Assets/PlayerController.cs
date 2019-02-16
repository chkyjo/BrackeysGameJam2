using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour{

    public Transform mainCameraTransform;

    public Rigidbody rb;

    public int walkSpeed;
    public int runSpeed;


    public float lookSensitivity = 5;
    float yaw = 0; //y rotation
    float pitch = 0; //x rotation

    // Update is called once per frame
    void FixedUpdate(){
        Move();
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

        Debug.Log(pitch);

        //x rotation of camera
        mainCameraTransform.localEulerAngles = new Vector3(-pitch, 0, 0);

        //y rotation of body
        transform.Rotate(0, Input.GetAxis("Mouse X") * lookSensitivity, 0);

    }
}
