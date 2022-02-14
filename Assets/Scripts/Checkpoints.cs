using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoints : MonoBehaviour
{
    GameObject resetPos;

    void Start()
    {
        resetPos = GameObject.Find("ResetPos");
    }

    private void OnTriggerEnter(Collider other) // need to sort out pivot point!
    {
        // move reset position to trigger position
        resetPos.transform.position = this.transform.position; 

        // disable trigger
        GetComponent<BoxCollider>().enabled = false;
        GetComponent<MeshRenderer>().enabled = false;
    }
}
