using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killbox : MonoBehaviour
{
    public CharacterController player;
    GameObject resetPos;

    private void Start()
    {
        resetPos = GameObject.Find("ResetPos");
    }

    private void OnTriggerEnter(Collider other)
    {
        // Kind of hacked but disables the player's CharacterController to teleport it
        player.enabled = false;
        player.transform.position = resetPos.transform.position;
        player.enabled = true;
    }
}
