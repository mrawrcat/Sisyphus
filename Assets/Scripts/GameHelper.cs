﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameHelper : MonoBehaviour
{
    public GameObject start_button;
    public RectTransform reviveButtonRect;
    public GameObject[] start_tilemaps;
    public Transform player;
    public Transform boulder;
    public Text distance;
    public Text coins;
    public Slider fatigue_counter;
    public Slider stop_counter;

    public Animator anim;
    private ObjectPoolNS pool;
    // Start is called before the first frame update
    void Start()
    {
        //reviveButtonRect.anchoredPosition = new Vector2(0, 500);
        pool = GameObject.Find("Tilemap").GetComponent<ObjectPoolNS>();
        anim = GetComponent<Animator>();

        /*
        GameManager.manager.coin_in_bank = PlayerPrefs.GetFloat("current_coins", 0);
        GameManager.manager.max_fatigue = PlayerPrefs.GetFloat("max_fatigue", 10);
        GameManager.manager.fatigue_recover_multiplier = PlayerPrefs.GetFloat("fatigue_recover", 5);
        GameManager.manager.fatigue_drain_rate = PlayerPrefs.GetFloat("fatigue_drain", 1);
        GameManager.manager.pushing_max = PlayerPrefs.GetFloat("max_hold", 3);
        GameManager.manager.pushing_drain_rate = PlayerPrefs.GetFloat("hold_time_drain", 1);
        GameManager.manager.fast_duration = PlayerPrefs.GetFloat("fast_duration", 0.9f);

        GameManager.manager.max_fatigue_coin_req = PlayerPrefs.GetFloat("max_fatigue_cost", 100);
        GameManager.manager.fatigue_recover_coin_req = PlayerPrefs.GetFloat("fatigue_recover_cost", 100);
        GameManager.manager.fatigue_drain_coin_req = PlayerPrefs.GetFloat("fatigue_drain_cost", 100);
        GameManager.manager.max_hold_coin_req = PlayerPrefs.GetFloat("max_hold_cost", 100);
        GameManager.manager.hold_drain_coin_req = PlayerPrefs.GetFloat("hold_time_drain_cost", 100);
        GameManager.manager.fast_duration_coin_req = PlayerPrefs.GetFloat("fast_duration_cost", 100);
        */

        stop_counter.maxValue = GameManager.manager.pushing_max;
        fatigue_counter.maxValue = GameManager.manager.max_fatigue;

        
    }

    // Update is called once per frame
    void Update()
    {
        stop_counter.value = GameManager.manager.pushing_time;
        fatigue_counter.value = GameManager.manager.fatigue;

        if(fatigue_counter.value < (GameManager.manager.max_fatigue * .8f))
        {
            
        }

        distance.text = GameManager.manager.distance_moved.ToString("F0") + " m";
        coins.text = GameManager.manager.coins.ToString("F0") + " coins";
        if (GameManager.manager.isUnder)
        {
            Move_Continue();
        }
        else
        {
            reviveButtonRect.anchoredPosition = new Vector2(0, 500);
        }

        if (!GameManager.manager.started)
        {
            start_button.SetActive(true);
        }
        else
        {
            start_button.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            //m_Fading = !m_Fading;
        }


        
    }

    public void Start_Game()
    {
        GameManager.manager.started = true;
    }

    public void Move_Continue()
    {
        //continue_panel.SetActive(true);
        reviveButtonRect.anchoredPosition = Vector2.Lerp(reviveButtonRect.anchoredPosition, new Vector2(0, 0), 5f * Time.deltaTime);
    }

    public IEnumerator Reload()
    {
        anim.SetTrigger("Start");
        yield return new WaitForSeconds(1f);
        Restart();
        yield return new WaitForSeconds(.25f);
        anim.SetTrigger("End");
        yield return new WaitForSeconds(.1f);
        GameManager.manager.can_start = true;
    }
    public void Reload_Restart()
    {
        StartCoroutine("Reload");
    }
    public void Restart()
    {

        pool.HideAllGridChild();
        
        for (int i = 0; i < start_tilemaps.Length; i++)
        {
            start_tilemaps[i].SetActive(true);
            start_tilemaps[i].transform.position = new Vector2(-60 + (30 * i), 0);
        }
        GameManager.manager.isUnder = false;
        GameManager.manager.dead = false;
        GameManager.manager.started = false;
        player.position = new Vector2(-6, -5.5f);
        boulder.GetComponent<Rock>().Reset_Boulder();
        GameManager.manager.coins = 0;
        GameManager.manager.distance_moved = 0;
        GameManager.manager.pushing_time = GameManager.manager.pushing_max;
        GameManager.manager.fatigue = GameManager.manager.max_fatigue;
        pool.tileheight = 15;

    }
}
