using UnityEngine;
using TMPro;
using Photon.Pun;

public class TakeCoin : MonoBehaviour
{
    public TextMeshProUGUI ScoreNum;

    string Score;
    [SerializeField] int Coin;
    private PhotonView View;

    private void Start()
    {
        View = GetComponent<PhotonView>();
        Score = Coin.ToString();
        ScoreNum = GameObject.FindGameObjectWithTag("Score").GetComponent<TextMeshProUGUI>();
        ScoreNum.text = Score;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (View.IsMine)
            if (other.CompareTag("Coin"))
            {
                Coin++;
                Score = Coin.ToString();
                ScoreNum.text = Score;
                Destroy(other.gameObject);
            }

    }
}