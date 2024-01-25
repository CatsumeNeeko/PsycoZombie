using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.Netcode;
using UnityEngine.SceneManagement;
using System.Linq;
    

public class NetworkManagerUI : MonoBehaviour
{
    public GameManager gameManager;
    [SerializeField] private Button ServerButton;
    [SerializeField] private Button HostButton;
    [SerializeField] private Button ClientButton;
    [SerializeField] Button StartButton;
    [SerializeField] GameObject[] players;
    private void Awake()
    {

        ServerButton.onClick.AddListener(() => {
            NetworkManager.Singleton.StartServer();

        });
        HostButton.onClick.AddListener(() => {
            NetworkManager.Singleton.StartHost();
            StartButton.gameObject.SetActive(true);
        });
        ClientButton.onClick.AddListener(() => {
            NetworkManager.Singleton.StartClient();

        });
        StartButton.onClick.AddListener(() =>
        {
            gameManager.gameStarted = true;
            
            players = GameObject.FindGameObjectsWithTag("Player");

            int listLength = players.Length;
            Debug.Log("PlayerAmmount :" + listLength);

            gameManager.playersAliveStart.Value = listLength;






            int randomIndex = Random.Range(0,listLength);
            Debug.Log(randomIndex.ToString());
            GameObject specificObject = players[randomIndex];
            
            PlayerMovement playerMovement = specificObject.gameObject.GetComponent<PlayerMovement>();
            if(playerMovement != null)
            {
                playerMovement.team = new NetworkVariable<int>(1);
            }
                
        });
    }
}
