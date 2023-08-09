using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int Health;    

    public int CurrentHealth;

    public Image ImageHP;
    public TextMeshProUGUI HPText;

    void Start()
    {
        CurrentHealth = Health;
        HPText.text = $"{ CurrentHealth} / {Health}";
        ImageHP.fillAmount = CurrentHealth / Health;
    }

    private void Update()
    {
        Death();
    }

    public void IncomingDamage(int Damage)
    {
        CurrentHealth -= Damage;
        HealthFill();
    }

    public void Death()
    {
        if (CurrentHealth <= 0)
        {
            PhotonNetwork.LeaveRoom();
        }
    }

    private void HealthFill()
    {
        ImageHP.fillAmount = CurrentHealth / Health;
        Debug.Log(ImageHP.fillAmount);
        HPText.text = $"{ CurrentHealth} / {Health}";
    }
}
