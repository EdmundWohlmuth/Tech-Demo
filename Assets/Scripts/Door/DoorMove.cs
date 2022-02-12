using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMove : MonoBehaviour
{
    // Declaration
    public bool isOpening;

    float speed;

    Vector3 minHeight;
    Vector3 maxHeight;
    Vector3 currentHeight;
    Vector3 yMovement;

    // Start is called before the first frame update
    void Start()
    {
        // Initlization
        speed = 8f;

        currentHeight = transform.position;
        minHeight = currentHeight;
        maxHeight = new Vector3(transform.position.x, transform.position.y + 2.5f, transform.position.z);

    }

    // Update is called once per frame
    void Update()
    {
        if (isOpening)
        {
            yMovement = currentHeight;
            yMovement *= 1;

            yMovement = new Vector3(transform.position.x, yMovement.y, transform.position.z);
            transform.Translate(yMovement * speed * Time.deltaTime);
        }
        else if (!isOpening)
        {
            yMovement = currentHeight;
            yMovement *= -1;

            yMovement = new Vector3(transform.position.x, yMovement.y, transform.position.z);
            transform.Translate(yMovement * speed * Time.deltaTime);
        }

        yMovement.y = Mathf.Clamp(yMovement.y, minHeight.y, maxHeight.y);
    }
}
