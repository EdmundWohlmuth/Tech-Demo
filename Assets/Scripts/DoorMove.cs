using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMove : MonoBehaviour
{
    public bool isOpening;
    float speed;
    public float maxHeight;
    public float minHeight;
    public float vertialHeight;

    public Vector3 currentHeight;

    // Start is called before the first frame update
    void Start()
    {
        currentHeight = transform.position;
        vertialHeight = currentHeight.y;
        minHeight = currentHeight.y;
        maxHeight = currentHeight.y + 2.7f;
        speed = 8f;
    }

    // Update is called once per frame
    void Update()
    {
        vertialHeight = transform.position.y;

        if (isOpening)
        {
            currentHeight = new Vector3(transform.position.x, currentHeight.y, transform.position.z);
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
        else if (!isOpening)
        {
            currentHeight = new Vector3(transform.position.x, currentHeight.y, transform.position.z);
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }

        vertialHeight = Mathf.Clamp(vertialHeight, minHeight, maxHeight);
    }
}

