using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunManager : MonoBehaviour
{
    [SerializeField] int currentAmmo = 0;
    [SerializeField] int maximunAmmo = 6;
    [SerializeField] int reserveAmmo = 1;
    [SerializeField] bool isReloading;
    [SerializeField] float reloadTime;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
        if(Input.GetKeyDown(KeyCode.R) && currentAmmo < maximunAmmo)
        {
            StartCoroutine(ReloadTimer());
        }
    }

    void Shoot()
    {
        if(currentAmmo != 0 && isReloading == false)
        {

        }
    }

    IEnumerator ReloadTimer()
    {
        isReloading = true;
        
        yield return new WaitForSeconds(reloadTime);

        isReloading = false;
        int ammoNeeded = maximunAmmo - currentAmmo;
        if(ammoNeeded <= reserveAmmo)
        {
            reserveAmmo -= ammoNeeded;
        }

    }
}
