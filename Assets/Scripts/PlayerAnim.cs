using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("pushing_time", GameManager.manager.pushing_time);
        anim.SetBool("dead", GameManager.manager.dead);
        anim.SetBool("pushing", GameManager.manager.pushing);
        anim.SetBool("can_control", GameManager.manager.can_control);
        anim.SetBool("fast", GameManager.manager.fast);
    }
}
