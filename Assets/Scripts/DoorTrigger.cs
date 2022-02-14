using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public GameObject door;

    private void OnTriggerEnter(Collider other)
    {
        door.GetComponent<DoorMove>().isOpening = true;
    }

    private void OnTriggerExit(Collider other)
    {
        door.GetComponent<DoorMove>().isOpening = false;
    }
}
