using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Vector3[] points;
    Vector3 currentTarget;

    //public GameObject player;  // re-enable if I need to specify

    public int pointNumber = 0;
    public bool automaticPlatform;

    float tolerance;
    float speed = 3f;
    float delayTime = 2f;
    float delayStart;


    // Start is called before the first frame update
    void Start()
    {
        if (points.Length > 0)
        {
            currentTarget = points[0];
        }
        tolerance = speed * Time.deltaTime;
    }

    // FixedUpdate is called every fixed framerate frame
    void FixedUpdate()
    {
        if (transform.position != currentTarget)
        {
            MovePlatform();
        }
        else
        {
            UpdateTarget();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        other.transform.parent = transform; // might have to specify player
    }
    private void OnTriggerExit(Collider other)
    {
        other.transform.parent = null;
    }

    void MovePlatform()
    {
        Vector3 heading = currentTarget - transform.position;
        transform.position += (heading / heading.magnitude) * speed * Time.deltaTime;
        if (heading.magnitude < tolerance)
        {
            transform.position = currentTarget;
            delayStart = Time.time;
        }
    }

    void UpdateTarget()
    {

        if (automaticPlatform)
        {
            if (Time.time - delayStart > delayTime)
            {
                NextPlatform();
            }
        }
    }

    public void NextPlatform()
    {
        pointNumber++;
        if (pointNumber >= points.Length)
        {
            pointNumber = 0;
        }
        currentTarget = points[pointNumber];
    }
}
