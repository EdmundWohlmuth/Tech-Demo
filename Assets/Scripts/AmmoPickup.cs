using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    public AudioSource source;
    public AudioClip pickUp;
    public AssaultRifle gun;

    private void Start()
    {
        
    }

    void Update()
    {
        this.gameObject.transform.Rotate(new Vector3(90, 0, 0) * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        source.PlayOneShot(pickUp);
        gun.GetComponent<AssaultRifle>().incrimentAmmo();

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
