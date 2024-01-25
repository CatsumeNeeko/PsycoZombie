using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.Networking;



public class GameManager : NetworkBehaviour
{
    public NetworkVariable<int> teamID;
    public NetworkVariable<int> playersAliveStart;
    public bool gameStarted;

}
