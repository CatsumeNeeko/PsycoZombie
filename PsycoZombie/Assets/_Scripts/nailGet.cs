using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class nailGet : MonoBehaviour
{
    [SerializeField] PlayerStats playerStats;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        playerStats.nailAmmount += Random.Range(4, 8);
        if(playerStats.nailAmmount > playerStats.maxNailAmmount)
        {
            playerStats.nailAmmount = playerStats.maxNailAmmount;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
