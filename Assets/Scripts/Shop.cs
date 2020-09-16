using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public Text current_coins;

    [Header("current stats")]
    public Text max_fatigue;
    public Text fatigue_recover_rate;
    public Text fatigue_drain_rate;
    public Text max_hold_time;
    public Text hold_time_drain_rate;
    public Text fast_duration;

    [Header("shop cost text")]
    public Text max_fatigue_cost;
    public Text fatigue_recover_rate_cost;
    public Text fatigue_drain_rate_cost;
    public Text max_hold_time_cost;
    public Text hold_time_drain_rate_cost;
    public Text fast_duration_cost;


    private void Start()
    {
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


    }
    // Update is called once per frame
    void Update()
    {
        Set_Texts();
    }

    private void Set_Texts()
    {
        current_coins.text = GameManager.manager.coin_in_bank.ToString("F0");

        max_fatigue.text = GameManager.manager.max_fatigue.ToString("F0");
        fatigue_recover_rate.text = GameManager.manager.fatigue_recover_multiplier.ToString("F0");
        fatigue_drain_rate.text = GameManager.manager.fatigue_drain_rate.ToString("F1");
        max_hold_time.text = GameManager.manager.pushing_max.ToString("F1");
        hold_time_drain_rate.text = GameManager.manager.pushing_drain_rate.ToString("F1");
        fast_duration.text = GameManager.manager.fast_duration.ToString("F2");


        
        max_fatigue_cost.text = GameManager.manager.max_fatigue_coin_req.ToString("F0");
        fatigue_recover_rate_cost.text = GameManager.manager.fatigue_recover_coin_req.ToString("F0");

        if(GameManager.manager.fatigue_drain_rate <= 0)
        {
            fatigue_drain_rate_cost.text = "Max";
        }
        else
        {
            fatigue_drain_rate_cost.text = GameManager.manager.fatigue_drain_coin_req.ToString("F0");
        }
        max_hold_time_cost.text = GameManager.manager.max_hold_coin_req.ToString("F0");

        if(GameManager.manager.pushing_drain_rate <= 0)
        {
            hold_time_drain_rate_cost.text = "Max";
        }
        else
        {
            hold_time_drain_rate_cost.text = GameManager.manager.hold_drain_coin_req.ToString("F0");
        }

        if(GameManager.manager.fast_duration <= 0)
        {
            fast_duration_cost.text = "Max";
        }
        else
        {
            fast_duration_cost.text = GameManager.manager.fast_duration_coin_req.ToString("F0");
        }
    }


    public void upgrade_max_fatigue()
    {
        if(GameManager.manager.coin_in_bank >= GameManager.manager.max_fatigue_coin_req)
        {
            GameManager.manager.coin_in_bank -= GameManager.manager.max_fatigue_coin_req;
            GameManager.manager.max_fatigue += 1;
            GameManager.manager.max_fatigue_coin_req += 200;
            PlayerPrefs.SetFloat("max_fatigue", GameManager.manager.max_fatigue);
            PlayerPrefs.SetFloat("max_fatigue_cost", GameManager.manager.max_fatigue_coin_req);
        }
    }

    public void upgrade_fatigue_recover()
    {
        if (GameManager.manager.coin_in_bank >= GameManager.manager.fatigue_recover_coin_req)
        {
            GameManager.manager.coin_in_bank -= GameManager.manager.fatigue_recover_coin_req;
            GameManager.manager.fatigue_recover_coin_req += 200;
            GameManager.manager.fatigue_recover_multiplier += .1f;
            PlayerPrefs.SetFloat("fatigue_recover", GameManager.manager.fatigue_recover_multiplier);
            PlayerPrefs.SetFloat("fatigue_recover_cost", GameManager.manager.fatigue_recover_coin_req);
        }
    }

    public void upgrade_fatigue_drain()
    {
        if (GameManager.manager.coin_in_bank >= GameManager.manager.fatigue_drain_coin_req)
        {
            if(GameManager.manager.fatigue_drain_rate > 0)
            {
                GameManager.manager.coin_in_bank -= GameManager.manager.fatigue_drain_coin_req;
                GameManager.manager.fatigue_drain_coin_req += 500;
                GameManager.manager.fatigue_drain_rate -= .1f;
                PlayerPrefs.SetFloat("fatigue_drain", GameManager.manager.fatigue_drain_rate);
                PlayerPrefs.SetFloat("fatigue_drain_cost", GameManager.manager.fatigue_drain_coin_req);
            }
        }
    }

    public void upgrade_hold_time()
    {
        if (GameManager.manager.coin_in_bank >= GameManager.manager.max_hold_coin_req)
        {
            GameManager.manager.coin_in_bank -= GameManager.manager.max_hold_coin_req;
            GameManager.manager.max_hold_coin_req += 200;
            GameManager.manager.pushing_max += .1f;
            PlayerPrefs.SetFloat("max_hold", GameManager.manager.pushing_max);
            PlayerPrefs.SetFloat("max_hold_cost", GameManager.manager.max_hold_coin_req);
        }
    }

    public void upgrade_hold_drain_rate()
    {
        if (GameManager.manager.coin_in_bank >= GameManager.manager.hold_drain_coin_req)
        {
            if(GameManager.manager.pushing_drain_rate > 0)
            {
                GameManager.manager.coin_in_bank -= GameManager.manager.hold_drain_coin_req;
                GameManager.manager.hold_drain_coin_req += 500;
                GameManager.manager.fatigue_drain_rate -= .01f;
                PlayerPrefs.SetFloat("hold_time_drain", GameManager.manager.pushing_drain_rate);
                PlayerPrefs.SetFloat("hold_time_drain_cost", GameManager.manager.hold_drain_coin_req);
            }
        }
    }

    public void upgrade_fast()
    {
        if(GameManager.manager.coin_in_bank >= GameManager.manager.fast_duration_coin_req)
        {
            if(GameManager.manager.fast_duration > 0)
            {
                GameManager.manager.coin_in_bank -= GameManager.manager.fast_duration_coin_req;
                GameManager.manager.fast_duration_coin_req += 500;
                GameManager.manager.fast_duration -= .05f;
                PlayerPrefs.SetFloat("fast_duration", GameManager.manager.fast_duration);
                PlayerPrefs.SetFloat("fast_duration_cost", GameManager.manager.fast_duration_coin_req);
            }
        }
    }
}
