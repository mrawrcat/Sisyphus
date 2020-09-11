using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager manager;
    public float Tilemap_Speed;
    public bool bossBattle;
    public float turn_tilemap_off;
    public bool spawned_checkpoint;
    public float distance_moved;


    [Header("Game/Player Status")]
    public bool dead;
    public bool movingReset;
    public bool isUnder;
    public bool started;
    public bool can_start;

    [Header("Game/Player Health and Stuff")]
    public float max_fatigue; //max stamina pool before stopping
    public float fatigue; // stamina gauge before stopping
    public float fatigue_recover_multiplier = 5; //rate that fatigue recovers
    public float fatigue_drain_rate = 1;
    public float pushed_rock;
    public float pushed_rock_timer;
    public float pushing_max; //max amt of time you can stay still
    public float pushing_time; //when you stop pushing -> amt of time until you cant hold on to boulder anymore
    public float pushing_drain_rate = 1; //rate that you hold
    public bool can_control;

    private void Awake()
    {
        if (manager == null)
        {
            manager = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (manager != this)
        {
            Destroy(gameObject);
        }

        fatigue = max_fatigue;
        pushing_time = pushing_max;
    }

    // Update is called once per frame
    void Update()
    {
        if (pushed_rock_timer > 0)
        {
            pushed_rock_timer -= Time.deltaTime;
            Tilemap_Speed = 10;
        }
        else
        {
            Tilemap_Speed = 0;
        }

        Calculate_Distance();

        if(pushing_time <= 0)//didnt push for awhile
        {
            dead = true;
        }

        

        

        if(fatigue <= 0 && can_control)
        {
            can_control = false;
        }
        else if (!can_control && fatigue >= 2)
        {
            can_control = true;
        }
        


        if(fatigue >= max_fatigue) //prevent fatigue being more than max fatigue
        {
            fatigue = max_fatigue;
        }
    }

    private void Calculate_Distance()
    {
        if(!dead && started)
        {
            distance_moved += Tilemap_Speed * Time.deltaTime;
        }
    }
}
