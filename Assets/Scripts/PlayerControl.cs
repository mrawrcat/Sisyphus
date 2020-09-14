using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    //public float refresh_push;
    //private float pushed_rock_timer;
    //public bool pushing;
    public bool hiding;

    private float wait_to_recover; //time to wait until fatigue bar starts to recover
    private Rigidbody2D rb2d;
    private CapsuleCollider2D cap_collider;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        cap_collider = GetComponent<CapsuleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Controls();

        if(!Input.GetButtonDown("Fire1") && !Input.GetButton("Fire1") && !GameManager.manager.dead && GameManager.manager.started)
        {
            GameManager.manager.pushing = false;
        }


        if (wait_to_recover > 0)
        {
            wait_to_recover -= Time.deltaTime;
        }
        else if (wait_to_recover <= 0)
        {
            wait_to_recover = 0;
        }

        if (!GameManager.manager.dead && GameManager.manager.started && GameManager.manager.pushing && GameManager.manager.can_control)
        {
            if(GameManager.manager.fatigue > 0)
            {
                GameManager.manager.fatigue -= GameManager.manager.fatigue_drain_rate * Time.deltaTime;
            }
        }
        else if (!GameManager.manager.dead && GameManager.manager.started && wait_to_recover <= 0)
        {
            if(GameManager.manager.fatigue < GameManager.manager.max_fatigue)
            {
                GameManager.manager.fatigue += GameManager.manager.fatigue_recover_multiplier * Time.deltaTime;
            }
        }

        if (GameManager.manager.dead)
        {
            cap_collider.isTrigger = true;
        }
        else
        {
            cap_collider.isTrigger = false;
        }
        /*
        if(GameManager.manager.pushed_rock_timer > 0)
        {
            rb2d.velocity = new Vector2(2, rb2d.velocity.y);
        }
        */

        if (!GameManager.manager.pushing || !GameManager.manager.can_control)
        {
            hiding = true;
        }
        else
        {
            hiding = false;
        }
    }


    private void Controls()
    {
        if(GameManager.manager.can_control)
        {
            if (Input.GetButtonDown("Fire1") && !GameManager.manager.dead && GameManager.manager.can_start)
            {
                GameManager.manager.pushing_time = GameManager.manager.pushing_max;
                GameManager.manager.started = true;
                GameManager.manager.can_start = false;
                wait_to_recover = 1f;
                GameManager.manager.pushing = true;
            }

            if (Input.GetButton("Fire1") && !GameManager.manager.dead && GameManager.manager.started)
            {
                GameManager.manager.pushing_time = GameManager.manager.pushing_max;
                wait_to_recover = 1f;
                GameManager.manager.pushing = true;
            }

        }
    }
}
