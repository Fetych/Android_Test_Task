using UnityEngine;
using TMPro;
using Photon.Pun;
using System.Collections.Generic;

public class PlayerManager : MonoBehaviourPun
{
    public TextMeshProUGUI NickName;
    public float Speed;
    public Joystick Joystick;

    private Rigidbody2D Rb;
    private float X, Y;
    private PhotonView View;

    void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
        View = GetComponent<PhotonView>();
        NickName.text = View.Owner.NickName;
        Joystick = GameObject.FindGameObjectWithTag("Joystick").GetComponent<Joystick>(); 
        FindObjectOfType<GameManager>().AddPlayer(this);
    }

    void Update()
    {
        if (View.IsMine)
        {
            X = Joystick.Horizontal * Speed;
            Y = Joystick.Vertical * Speed;
        }

    }

    void FixedUpdate()
    {
        if (View.IsMine)
            Rb.velocity = new Vector2(X, Y);
    }
}
