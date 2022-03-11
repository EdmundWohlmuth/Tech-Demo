using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthPickUp : MonoBehaviour
{
    public AudioSource source;
    public AudioClip pickUp;
    public GameObject player;

    void Update()
    {
        this.gameObject.transform.Rotate(new Vector3(90, 0, 0) * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        source.PlayOneShot(pickUp);
        player.GetComponent<AssaultRifle>().incrimentHealth();

        GetComponent<BoxCollider>().enabled = false;
        GetComponent<MeshRenderer>().enabled = false;

        StartCoroutine(ItemResetTime(10f));
    }

    IEnumerator ItemResetTime(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        GetComponent<BoxCollider>().enabled = true;
        GetComponent<MeshRenderer>().enabled = true;
    }

}

