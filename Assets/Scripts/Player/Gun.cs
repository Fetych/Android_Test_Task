using UnityEngine;
using Photon.Pun;

public class Gun : MonoBehaviour
{
    public Joystick Joystick;
    public GameObject Bullet;
    public Transform ShotPoint;
    public float Offset;
    public float StartTimeShots;

    private float RotZ;
    private float TimeShots;
    public PhotonView View;

    void Start()
    {
        Joystick = GameObject.FindGameObjectWithTag("JoystickGun").GetComponent<Joystick>();
    }

    void Update()
    {
        if (View.IsMine)
        {
            if (Mathf.Abs(Joystick.Horizontal) > 0.3f || Mathf.Abs(Joystick.Vertical) > 0.3f)
                RotZ = Mathf.Atan2(Joystick.Vertical, Joystick.Horizontal) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, RotZ + Offset);
            if (TimeShots <= 0)
            {
                if (Joystick.Horizontal != 0 || Joystick.Vertical != 0)
                    Shoot();
            }
            else
            {
                TimeShots -= Time.deltaTime;
            }
        }
    }

    public void Shoot()
    {
        GameObject BulletA;
        BulletA = Instantiate(Bullet, ShotPoint.position, transform.rotation);
        BulletA.GetComponent<Bullet>().CheckBullet();
        TimeShots = StartTimeShots;
    }
}
