using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Realtime;
using Photon.Pun;

public class ListItem : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI TextName, TextPlayerCount;

    public void SetInfo(RoomInfo Info)
    {
        TextName.text = Info.Name;
        TextPlayerCount.text = Info.PlayerCount + "/" + Info.MaxPlayers;
    }

    public void JoinToListRoom()
    {
        PhotonNetwork.JoinRoom(TextName.text);
    }
}
