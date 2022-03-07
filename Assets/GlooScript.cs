using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlooScript : MonoBehaviour
{
    float aliveTime;

    float x = 1;
    float y = 1;
    float z = 1;

// Start is called before the first frame update
void Start()
    {
        aliveTime = 30f;
    }

    // Update is called once per frame
    void Update()
    {
        aliveTime -= Time.deltaTime;

        if (aliveTime <= 0)
        {
            GetComponent<SphereCollider>().enabled = false;
            GetComponent<MeshRenderer>().enabled = false;
        }
    }

    private void FixedUpdate()
    {


        while (aliveTime > 0)
        {
            if (x > 10) transform.localScale = new Vector3(x + 1f, y + 1f, z + 1f);
            else transform.localScale = new Vector3(x, y, z);

        }
    }

}
