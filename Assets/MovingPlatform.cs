using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Vector3[] points;
    Vector3 moveDirection;

    //public GameObject player;  // re-enable if I need to specify

    public int pointNumber = 0;
    public bool automaticPlatform;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        transform.parent = transform; // might have to specify player
        movePlatform();
    }
    private void OnTriggerExit(Collider other)
    {
        transform.parent = null;
    }

    void movePlatform()
    {

    }
}
