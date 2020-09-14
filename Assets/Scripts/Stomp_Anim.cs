using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stomp_Anim : MonoBehaviour
{
    public Animator anim;
    private Mover_Up_Down move;
    // Start is called before the first frame update
    void Start()
    {
        //anim = GetComponent<Animator>();
        move = GetComponent<Mover_Up_Down>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("time_to_stomp_time", move.time_to_stomp_time);
    }
}
