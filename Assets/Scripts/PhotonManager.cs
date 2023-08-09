using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine.SceneManagement;

public class PhotonManager : MonoBehaviourPunCallbacks
{
    [SerializeField] string Region;

    [SerializeField] TMP_InputField RoomName;
    [SerializeField] ListItem ItemPrefab;
    [SerializeField] Transform Content;

    List<RoomInfo> AllRooms = new List<RoomInfo>();

    private GameObject Player;
    [SerializeField] GameObject PlayerPrefab, CoinPrefab;

    private void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
        if (SceneManager.GetActiveScene().name == "Game")
        {
            Vector2 Pos = new Vector2(Random.Range(-8.9f, 8.9f), Random.Range(-5f, 5f));
            
            Player = PhotonNetwork.Instantiate(PlayerPrefab.name, Pos, Quaternion.identity);
            Player.GetComponent<SpriteRenderer>().color = Color.green;
            for(int i = 0; i < 10; i++)
            {
                Vector2 PosCoin = new Vector2(Random.Range(-8.9f, 8.9f), Random.Range(-5f, 5f));
                PhotonNetwork.Instantiate(CoinPrefab.name, PosCoin, Quaternion.identity);
            }
        }
    }

    public override void OnConnectedToMaster()
    {
        if (!PhotonNetwork.InLobby)
            PhotonNetwork.JoinLobby();
    }

    public void CreatRoomButton()
    {
        if (!PhotonNetwork.IsConnected)
            return;
        RoomOptions RoomOptions = new RoomOptions();
        RoomOptions.MaxPlayers = 10;
        PhotonNetwork.CreateRoom(RoomName.text, RoomOptions, TypedLobby.Default);
    }

    public override void OnRoomListUpdate(List<RoomInfo> RoomList)
    {
        foreach(RoomInfo Info in RoomList)
        {
            for(int i = 0; i < AllRooms.Count; i++)
            {
                if (AllRooms[i].masterClientId == Info.masterClientId)
                    return;
            }
            ListItem ListItem = Instantiate(ItemPrefab, Content);
            if (ListItem != null)
            {
                ListItem.SetInfo(Info);
                AllRooms.Add(Info);
            }
        }
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Game");
    }

    public void JoinButton()
    {
        PhotonNetwork.JoinRoom(RoomName.text);
    }

    public void LeaveButton()
    {
        PhotonNetwork.LeaveRoom();
    }

    public override void OnLeftRoom()
    {
        PhotonNetwork.Destroy(Player.gameObject);
        PhotonNetwork.LoadLevel("Lobby");
    }
}
