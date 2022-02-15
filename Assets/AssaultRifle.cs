using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssaultRifle : MonoBehaviour
{
    public Camera playerCam;
    public float range;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Fire();
        }
    }

    void Fire()
    {
        Debug.Log("Bang!");

        RaycastHit hit;
        if (Physics.Raycast(playerCam.transform.position, playerCam.transform.forward, out hit, range))
        {
            GameObject Sphere;           
            Sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);

            Sphere.transform.position = hit.point;
        }
    }
}