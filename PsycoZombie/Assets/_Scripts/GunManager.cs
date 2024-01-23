using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunManager : MonoBehaviour
{
    [SerializeField] int currentAmmo = 0;
    [SerializeField] int maximumAmmo = 6;
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
        if(Input.GetKeyDown(KeyCode.R) && currentAmmo < maximumAmmo)
        {
            StartCoroutine(ReloadTimer());
        }
    }

    void Shoot()
    {
        if(currentAmmo != 0 && isReloading == false)
        {
            currentAmmo--;
            Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
            float rayDistance = 100f;
            RaycastHit hit;

            if(Physics.Raycast(ray,out hit, rayDistance))
            {
                Debug.Log("Hit Object " + hit.collider.gameObject.name);
            }
        }
    }

    IEnumerator ReloadTimer()
    {
        isReloading = true;
        
        yield return new WaitForSeconds(reloadTime);

        isReloading = false;
        int ammoNeeded = maximumAmmo - currentAmmo;
        if(ammoNeeded <= reserveAmmo)
        {
            reserveAmmo -= ammoNeeded;
            currentAmmo += ammoNeeded;
        }
        else if(reserveAmmo < maximumAmmo)
        {
            currentAmmo += reserveAmmo;
            reserveAmmo = 0;
        }

    }
}
