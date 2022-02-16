using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMove : MonoBehaviour
{
    public bool isOpening;

    float speed = 5f;
    Vector3 closedPos;
    Vector3 openPos;

    // Start is called before the first frame update
    void Start()
    {
        closedPos = transform.position;
        openPos = new Vector3(transform.position.x, transform.position.y + 2.7f, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (isOpening)
        {
            OpenCloseDoor(openPos);
        }
        else if (!isOpening)
        {
            OpenCloseDoor(closedPos);
        }
    }

    void OpenCloseDoor(Vector3 destination)
    {
        float distance = Vector3.Distance(transform.position, destination);
        if (distance > 0.1f)
        {
            transform.position = Vector3.Lerp(transform.position, destination, speed * Time.deltaTime);
        }
    }

}

