using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private CamShake shake;
    private void Start()
    {
        shake = FindObjectOfType<CamShake>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if (!GameManager.manager.dead)
            {
                if(GameManager.manager.invincible <= 0)
                {
                    shake.Shake();
                    GameManager.manager.pushing_time = 0;
                    GameManager.manager.dead = true;
                }
            }
            
        }
    }
}
