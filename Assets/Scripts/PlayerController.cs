using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float horizontalMovement;
    float verticalMovement;
    Vector3 characterMovement;
    Vector3 velocity;

    float gravity;
    float jumpHeight;

    float cameraPitch;

    float speedModifer;
    float lookSensitivity;

    bool isPaused = false;

    public Transform playerCamera;
    public CharacterController controller;

    // Start is called before the first frame update
    void Start()
    {
        // init
        speedModifer = 4f;
        lookSensitivity = 10f;
        cameraPitch = 0.0f;
        gravity = -9.81f;
        jumpHeight = 5.0f;
    }

    // Update is called once per frame
    void Update()
    {       
        Move();
        Look();
        Jump();
        Falling();
        Paused();


    }

    // -------------------------------------------------------------- Movement
    void Move()
    {          
        horizontalMovement = Input.GetAxis("Horizontal");
        verticalMovement = Input.GetAxis("Vertical");

        Vector3 move = transform.right * horizontalMovement + transform.forward * verticalMovement;

        controller.Move(move * speedModifer * Time.deltaTime);
      
    }

    // ------------------------------------------------------------- Mouse Look
    void Look()
    {
        Vector2 mouseLook = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y") * lookSensitivity);

        cameraPitch -= mouseLook.y; 
        cameraPitch = Mathf.Clamp(cameraPitch, -90, 90);
        playerCamera.localEulerAngles = Vector3.right * cameraPitch;

        transform.Rotate(Vector3.up * mouseLook.x);
    }

    // -------------------------------------------------------------- Jumping
    void Jump()
    {

    }

    // ---------- I'll figure this out later --------------------- isGrounded
    void Falling()
    {
        if (!controller.isGrounded)
        {
            velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);
        }
        else
        {
            velocity.y = 0f;
        }
        
    }

    // *might move* ---------------------------------------------- Pause functions
    void Paused()
    {
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused)
            {
                isPaused = true;
            }

            isPaused = false;
        }

        if (!isPaused)
        {
            // Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        if (isPaused)
        {
            // Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
