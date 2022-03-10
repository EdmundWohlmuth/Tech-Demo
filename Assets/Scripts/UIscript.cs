using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIscript : MonoBehaviour
{
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

    void Update()
    {

    }


    void setAmmoText()
    {
        ammoText.text = "Ammo: " + ammoCount.ToString();
    }
    void setHealthText()
    {
        healthText.text = "Health: " + health.ToString();
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
}
