using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;


public class PlayerStats : NetworkBehaviour
{
    public bool hasToolBox = false;
    public int nailAmmount = 0;
    public int maxNailAmmount = 12;
    public float maxHealth = 100f;
}
