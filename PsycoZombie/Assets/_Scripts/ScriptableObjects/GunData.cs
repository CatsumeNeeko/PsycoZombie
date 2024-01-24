using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Gun", menuName ="Guns")]
public class GunData : ScriptableObject
{
    [Header("Gun Infomation")]
    public new string name;
    public GameObject model;

    [Header("Ammo Stats")]
    public int maxMagazine;
    public int maxReserve;
    public float reloadTime;
    public int pellets;

    [Header("Damage stats")]
    public float damage;
    public float bulletDistance;
}
