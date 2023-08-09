using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Speed, Distance,LifeTime;
    public int Damage;
    public LayerMask PlayerMask;

    private void Start()
    {
        Invoke("DestroyBullet", LifeTime);
    }

    private void Update()
    {
        transform.Translate(Vector2.up * Speed * Time.deltaTime);
    }

    public void CheckBullet()
    {
        RaycastHit2D HitInfo = Physics2D.Raycast(transform.position, transform.up, Distance, PlayerMask);
        if (HitInfo.collider != null)
        {
            if (HitInfo.collider.GetComponent<PlayerHealth>() != null)
            {
                HitInfo.collider.GetComponent<PlayerHealth>().IncomingDamage(Damage);
                DestroyBullet();
            }
            DestroyBullet();
        }       
    }

    public void DestroyBullet()
    {
        Destroy(gameObject);
    }
}
