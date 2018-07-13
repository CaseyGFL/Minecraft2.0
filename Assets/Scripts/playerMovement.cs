using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour {

    public enum RotationAxis
    {
        MouseX = 1,
        MouseY = 2
    }
    float vertical;
    float horizontal;
    public float horizontalSpeed = 2.0F;
    public GameObject camera;
    public float _rotationX = 0;
    public RotationAxis axes = RotationAxis.MouseX;
    private float speed = 0.1f;
    private float jumpForce = 0.5f;
    private float gravity = 2f;
    private Vector3 moveDir = Vector3.zero;
    CharacterController controller;

    void Start () {
        controller = gameObject.GetComponent<CharacterController>();
        camera = transform.Find("Main Camera").gameObject;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
	

	void Update () {

            RunCheck();
            PlayerAndCamControll();

    }

    private void RunCheck()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 0.2f;
        }
        else
        {
            speed = 0.1f;
        }
    }

    private void PlayerAndCamControll()
    {
        float h = horizontalSpeed * Input.GetAxis("Mouse X");



        if (controller.isGrounded)
        {
            moveDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDir = transform.TransformDirection(moveDir);
            moveDir *= speed;
            if (Input.GetButtonDown("Jump"))
            {
                moveDir.y = jumpForce;
            }

        }

        moveDir.y -= gravity * Time.deltaTime;
        controller.Move(moveDir);
        transform.Rotate(0, h, 0);

        _rotationX -= Input.GetAxis("Mouse Y") * horizontalSpeed;
        _rotationX = Mathf.Clamp(_rotationX, -55.0f, 55.0f);
        float rotationY = camera.transform.localEulerAngles.y;
        camera.transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
    }
}
