using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killbox : MonoBehaviour
{
    public CharacterController player;
    GameObject resetPos;
    public AudioSource source;
    public AudioClip sound;

    private void Start()
    {
        resetPos = GameObject.Find("ResetPos");
    }

    private void OnTriggerEnter(Collider other)
    {
        // Kind of hacked but disables the player's CharacterController to teleport it
        player.enabled = false;
        player.transform.position = resetPos.transform.position;
        source.PlayOneShot(sound);
        player.enabled = true;
    }
}
