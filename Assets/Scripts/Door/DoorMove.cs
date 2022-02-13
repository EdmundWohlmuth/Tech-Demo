using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMove : MonoBehaviour
{
    public bool isOpening;
    float speed;
    Vector3 maxHeight;
    Vector3 minHeight;
    Vector3 currentHeight;
    Vector3 yMovement;

    // Start is called before the first frame update
    void Start()
    {
        currentHeight = transform.position;
        minHeight = currentHeight;
        maxHeight = new Vector3(transform.position.x, transform.position.y + 2.5f, transform.position.z);
        speed = 8f;
    }

    // Update is called once per frame
    void Update()
    {
        if (isOpening)
        {
            yMovement = currentHeight;
            yMovement *= 1;

            currentHeight = new Vector3(transform.position.x, currentHeight.y, transform.position.z);
            transform.Translate(currentHeight * speed * Time.deltaTime);

        }
        else if (!isOpening)
        {
            yMovement = currentHeight;
            yMovement *= -1;

            currentHeight = new Vector3(transform.position.x, currentHeight.y, transform.position.z);
            transform.Translate(yMovement * speed * Time.deltaTime);
        }

    }
}

