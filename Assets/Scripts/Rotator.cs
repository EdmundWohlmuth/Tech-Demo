using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public Vector3 rotationValues;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotationValues * Time.deltaTime);
            
    }
}
