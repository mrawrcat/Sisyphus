using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShootEvent : MonoBehaviour
{
    public ObjectPoolNS bullet_pool;
    public Transform shootPos;
    private Pig boss;

    private void Start()
    {
        boss = GetComponentInChildren<Pig>();
        bullet_pool = GameObject.Find("Enemy Projectile Pool").GetComponent<ObjectPoolNS>();
    }

    public void Boss_Shoot()
    {
        bullet_pool.SpawnProjectile(shootPos);
        boss.shoot_timer = 2f;
        boss.attacked = false;
        //boss.charging = 0;

    }
}
