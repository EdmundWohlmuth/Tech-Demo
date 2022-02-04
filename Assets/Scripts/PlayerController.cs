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
    bool isGrounded;

    public Transform playerCamera;
    public CharacterController controller;

    // Start is called before the first frame update
    void Start()
    {
        // init
        speedModifer = 10f;
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
        Shoot();
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
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }

    // --------------------------------------------------------------- isGrounded
    void Falling()
    {
        RaycastHit hit;

        isGrounded = Physics.Raycast(transform.position, Vector3.down, out hit, 1.6f);
        Debug.DrawRay(transform.position, Vector3.down);

        if (isGrounded)
        {
            velocity.y -= 0.1f * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);
        }
        else if (!isGrounded)
        {
            // gravity
            velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);
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

    // --------------------- WIP ------------------------------------ Shooting

    void Shoot()
    {
        RaycastHit hit;

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Pew");
            Physics.Raycast(playerCamera.transform.position, Vector3.forward, out hit, 50f);
            Debug.DrawRay(transform.position, Vector3.forward);
        }
    }
}
