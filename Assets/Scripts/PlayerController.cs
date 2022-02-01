using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float horizontalMovement;
    float verticalMovement;
    float gravity;
    float gravityVelocity;

    float cameraPitch;

    float speedModifer;
    float lookSensitivity;

    public Transform playerCamera;
    CharacterController controller = null;

    // Start is called before the first frame update
    void Start()
    {
        // init
        speedModifer = 4f;
        lookSensitivity = 5f;
        cameraPitch = 0.0f;
        gravity = 9.81f;
        gravityVelocity = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
        PlayerLook();
    }

    // -------------------------------------------------------------- WASD Movement
    void PlayerMove()
    {     
        horizontalMovement = Input.GetAxis("Horizontal") * speedModifer * Time.deltaTime;
        transform.Translate(horizontalMovement, 0, 0);

        verticalMovement = Input.GetAxis("Vertical") * speedModifer * Time.deltaTime;
        transform.Translate(0, 0, verticalMovement);

        if (controller.isGrounded)
        {
            gravityVelocity = 0.0f;
        }
        gravityVelocity += gravity * Time.deltaTime;
    }

    // ------------------------------------------------------------- Mouse Look
    void PlayerLook()
    {
        Vector2 mouseLook = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y") * lookSensitivity);

        cameraPitch -= mouseLook.y * lookSensitivity; // 
        cameraPitch = Mathf.Clamp(cameraPitch, -90, 90);
        playerCamera.localEulerAngles = Vector3.right * cameraPitch;

        transform.Rotate(Vector3.up * mouseLook.x);
    }
}
