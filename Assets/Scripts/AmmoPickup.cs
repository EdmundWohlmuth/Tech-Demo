using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    void Update()
    {
        this.gameObject.transform.Rotate(new Vector3(90, 0, 0) * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
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
