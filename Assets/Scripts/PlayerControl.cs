using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float pushed_rock;
    public float refresh_push;
    //private float pushed_rock_timer;
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
        if (Input.GetButtonDown("Fire1") && !GameManager.manager.dead)
        {
            GameManager.manager.pushed_rock_timer = pushed_rock;
            GameManager.manager.pushing_time = refresh_push;
        }

        if (Input.GetButton("Fire1") && !GameManager.manager.dead && GameManager.manager.started)
        {
            GameManager.manager.pushed_rock_timer = pushed_rock;
            GameManager.manager.pushing_time = refresh_push;
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
    }
}
