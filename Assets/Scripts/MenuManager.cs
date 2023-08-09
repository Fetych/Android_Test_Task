using UnityEngine;
using TMPro;
using Photon.Pun;

public class MenuManager : MonoBehaviour
{
    [SerializeField] string NickName;
    [SerializeField] TextMeshProUGUI TextNick;
    [SerializeField] TMP_InputField NickField;

    private void Start()
    {
        if (PlayerPrefs.HasKey("Nick"))
        {
            NickName = PlayerPrefs.GetString("Nick");
        }
        else
        {
            NickName = "User";
        }
        if(TextNick != null)
            TextNick.text = NickName;
        PhotonNetwork.NickName = NickName;
    }

    public void NickNameButton()
    {
        NickName = NickField.text;
        TextNick.text = NickField.text;
        PlayerPrefs.SetString("Nick", NickName);
        PhotonNetwork.NickName = NickField.text;
    }
}
