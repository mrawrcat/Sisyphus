using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pig : MonoBehaviour
{
    public Animator anim;
    public float shoot_timer;
    private bool in_detect_field;
    public bool attacked;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (in_detect_field)
        {
            shoot_timer -= Time.deltaTime;
        }

        if(shoot_timer <= 0)
        {
            if (!attacked)
            {
                anim.SetTrigger("Attack");
                attacked = true;
            }
            //shoot_timer = 2;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            in_detect_field = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            in_detect_field = false;
        }
    }
}
