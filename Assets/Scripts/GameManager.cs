using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager manager;

    [Header("Game/Player Stuff")]
    public int level;
    public float coins;
    public float max_exp;
    public float exp;

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
    public bool toggle_invincible;
    public float invincible;

    [Header("Game/Player Health and Stuff")]
    public float max_fatigue; //max stamina pool before stopping
    public float fatigue; // stamina gauge before stopping
    public float fatigue_recover_multiplier = 5; //rate that fatigue recovers
    public float fatigue_drain_rate = 1;
    public float pushing_max; //max amt of time you can stay still
    public float pushing_time; //when you stop pushing -> amt of time until you cant hold on to boulder anymore
    public float pushing_drain_rate = 1; //rate that you hold
    public float fast_duration = .9f;
    public bool can_control;
    public bool pushing;
    public bool fast;

    [Header("Shop Stuff")]
    public float max_fatigue_coin_req;
    public float fatigue_recover_coin_req;
    public float fatigue_drain_coin_req;
    public float max_hold_coin_req;
    public float hold_drain_coin_req;
    public float fast_duration_coin_req;


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
        float two_thirds = max_fatigue * fast_duration;
        if (pushing && fatigue > two_thirds && fatigue > 0 && !dead && can_control)
        {
            Tilemap_Speed = 20;
            fast = true;
        }
        else if(pushing && fatigue < two_thirds && fatigue > 0 && !dead && can_control)
        {
            Tilemap_Speed = 10;
            fast = false;
        }
        else
        {
            Tilemap_Speed = 0;
            fast = false;
        }

        Calculate_Distance();

        if(pushing_time <= 0)//didnt push for awhile
        {
            dead = true;
        }


        if (dead)
        {
            pushing = false;
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

        if (toggle_invincible)
        {
            invincible = 10;
        }
        else if(!toggle_invincible && invincible >= 0)
        {
            invincible -= Time.deltaTime;
        }

        Calculate_Exp();
    }

    private void Calculate_Distance()
    {
        if(!dead && started)
        {
            distance_moved += Tilemap_Speed * Time.deltaTime;
        }
    }

    public void Calculate_Exp()
    {
        if(exp >= max_exp)
        {
            exp = 0;
            level++;
        }
    }
}
