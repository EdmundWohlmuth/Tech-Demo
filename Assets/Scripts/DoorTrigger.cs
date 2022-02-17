using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public GameObject door;
    public AudioSource source;
    public AudioClip openSound;
    public AudioClip closeSound;

    private void OnTriggerEnter(Collider other)
    {
        source.PlayOneShot(openSound);
        door.GetComponent<DoorMove>().isOpening = true;
    }

    private void OnTriggerExit(Collider other)
    {
        source.PlayOneShot(closeSound);
        door.GetComponent<DoorMove>().isOpening = false;
    }
}
