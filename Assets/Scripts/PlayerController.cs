using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float horizontalMovement;
    float verticalMovement;
    Vector3 characterMovement;

    float gravity;
    float jumpHeight;

    float cameraPitch;

    float speedModifer;
    float lookSensitivity;

    bool isPaused = false;

    float velocityY;

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
        horizontalMovement = Input.GetAxis("Horizontal") * speedModifer * Time.deltaTime;
        transform.Translate(horizontalMovement, 0, 0);

        verticalMovement = Input.GetAxis("Vertical") * speedModifer * Time.deltaTime;
        transform.Translate(0, 0, verticalMovement);

        characterMovement = new Vector3(horizontalMovement, velocityY, verticalMovement);
      
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
        if (Input.GetKeyDown(KeyCode.Space) && controller.isGrounded)
        {
            velocityY += Mathf.Sqrt(jumpHeight * -3.0f * gravity);
        }
    }

    // ---------- I'll figure this out later --------------------- isGrounded
    void Falling()
    {
        if (controller.isGrounded && velocityY < 0)
        {
            Debug.Log("is grounded");
            velocityY = 0;
        }
        else
        {
            Debug.Log("isn't grounded");

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
