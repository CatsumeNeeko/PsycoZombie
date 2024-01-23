using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class PlayerCam : NetworkBehaviour
{
    public GameObject CamHolder;
    public Vector3 Offset;

    public override void OnNetworkSpawn()
    {
        CamHolder.SetActive(IsOwner);
        base.OnNetworkSpawn();
    }

    public void Start()
    {
        CamHolder.transform.position = transform.position + Offset;
    }
}
