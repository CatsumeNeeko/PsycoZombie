using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunManager : MonoBehaviour
{
    public GunData gunData;


    [SerializeField] int currentAmmo = 0;
    [SerializeField] int reserveAmmo = 1;
    [SerializeField] bool isReloading;
    [SerializeField] float reloadTime;
    [SerializeField] Camera cam;

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
        if(Input.GetKeyDown(KeyCode.R) && currentAmmo < gunData.maxMagazine && isReloading == false)
        {
            StartCoroutine(ReloadTimer());
        }
    }

    void Shoot()
    {
        if(currentAmmo != 0 && isReloading == false)
        {
            currentAmmo--;

            for(int i = 0; i < gunData.pellets;  i++)
            {
                Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, gunData.bulletDistance))
                {
                    Debug.Log("Hit Object " + hit.collider.gameObject.name);
                    Debug.DrawRay(ray.origin, ray.direction * gunData.bulletDistance, Color.red, 1f);
                }
            }
        }
    }

    IEnumerator ReloadTimer()
    {
        isReloading = true;
        
        yield return new WaitForSeconds(reloadTime);

        isReloading = false;
        int ammoNeeded = gunData.maxMagazine - currentAmmo;
        if(ammoNeeded <= reserveAmmo)
        {
            reserveAmmo -= ammoNeeded;
            currentAmmo += ammoNeeded;
        }
        else if(reserveAmmo < gunData.maxMagazine)
        {
            currentAmmo += reserveAmmo;
            reserveAmmo = 0;
        }

    }
}
