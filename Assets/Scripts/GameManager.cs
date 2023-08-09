using UnityEngine;
using Photon.Pun;
using TMPro;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI TextLastMessage;
    [SerializeField] TMP_InputField TextMessageField;

    private PhotonView PhotonView;


    [SerializeField] List<PlayerManager> Players = new List<PlayerManager>();

    public void AddPlayer(PlayerManager Player)
    {
        Players.Add(Player);
    }

    private void Start()
    {
        PhotonView = GetComponent<PhotonView>();
    }
}
