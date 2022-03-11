using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AssaultRifle : MonoBehaviour
{
    public Camera playerCam;
    public AudioSource source;
    public AudioClip shootSound;
    public AudioClip shootSound2;
    
    public float range;

    public int ammo;
    public int ammoCount = 10;
    private int health = 50;

    public TextMeshProUGUI ammoText;
    public TextMeshProUGUI healthText;

    // Start is called before the first frame update
    void Start()
    {
        setAmmoText();
        setHealthText();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && ammoCount > 0)
        {
            ammoCount--;
            setAmmoText();
            Fire();
            int randomNum = Random.Range(1, 3);
            if (randomNum == 1)
            {
                source.PlayOneShot(shootSound);
            }
            else source.PlayOneShot(shootSound2);
        }
        else
        {
            // play sound click
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
            Sphere.transform.parent = hit.transform;
        }
    }

    // ------------------------- Pickups ------------------------------------------
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("AmmoPickup"))
        {
            Debug.Log("Picked up ammo");
            ammoCount = ammoCount + 10;

            if (ammoCount >= 50) ammoCount = 50;
            else if (ammoCount <= 0) ammoCount = 0;
            setAmmoText();
        }

        if (other.gameObject.CompareTag("HealthPickup"))
        {
            Debug.Log("Picked up health");
            health = health + 25;

            if (health >= 150) health = 150;
            else if (health <= 0) health = 0;
            setHealthText();
        }
    }

    public void incrimentAmmo()
    {
        Debug.Log("Picked up ammo");
        ammoCount = ammoCount + 10;

        if (ammoCount >= 50) ammoCount = 50;
        else if (ammoCount <= 0) ammoCount = 0;
        setAmmoText();
    }
    public void incrimentHealth()
    {
        Debug.Log("Picked up health");
        health = health + 25;

        if (health >= 150) health = 150;
        else if (health <= 0) health = 0;
        setHealthText();
    }

    // ------------------------- set UI --------------------------------------
    void setAmmoText()
    {
        ammoText.text = "Ammo: " + ammoCount.ToString();
    }
    void setHealthText()
    {
        healthText.text = "Health: " + health.ToString();
    }
}
