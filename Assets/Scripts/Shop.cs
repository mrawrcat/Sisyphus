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

    [Header("shop cost text")]
    public Text max_fatigue_cost;
    public Text fatigue_recover_rate_cost;
    public Text fatigue_drain_rate_cost;
    public Text max_hold_time_cost;
    public Text hold_time_drain_rate_cost;

    // Update is called once per frame
    void Update()
    {
        Set_Texts();
    }

    private void Set_Texts()
    {
        current_coins.text = GameManager.manager.coins.ToString("F0");

        max_fatigue.text = GameManager.manager.max_fatigue.ToString("F0");
        fatigue_recover_rate.text = GameManager.manager.fatigue_recover_multiplier.ToString("F0");
        fatigue_drain_rate.text = GameManager.manager.fatigue_drain_rate.ToString("F0");
        max_hold_time.text = GameManager.manager.pushing_max.ToString("F0");
        hold_time_drain_rate.text = GameManager.manager.pushing_drain_rate.ToString("F0");


        max_fatigue_cost.text = GameManager.manager.max_fatigue_coin_req.ToString("F0");
        fatigue_recover_rate_cost.text = GameManager.manager.fatigue_recover_coin_req.ToString("F0");
        fatigue_drain_rate_cost.text = GameManager.manager.fatigue_drain_coin_req.ToString("F0");
        max_hold_time_cost.text = GameManager.manager.max_hold_coin_req.ToString("F0");
        hold_time_drain_rate_cost.text = GameManager.manager.hold_drain_coin_req.ToString("F0");
    }


    public void upgrade_max_fatigue()
    {
        if(GameManager.manager.coins >= GameManager.manager.max_hold_coin_req)
        {
            GameManager.manager.coins -= GameManager.manager.max_hold_coin_req;
            GameManager.manager.max_fatigue += 1;
            GameManager.manager.max_hold_coin_req += 200;
        }
    }

    public void upgrade_fatigue_recover()
    {
        if (GameManager.manager.coins >= GameManager.manager.max_hold_coin_req)
        {
            GameManager.manager.coins -= GameManager.manager.max_hold_coin_req;
            GameManager.manager.max_hold_coin_req += 200;
        }
    }

    public void upgrade_fatigue_drain()
    {
        if (GameManager.manager.coins >= GameManager.manager.max_hold_coin_req)
        {
            GameManager.manager.coins -= GameManager.manager.max_hold_coin_req;
            GameManager.manager.max_hold_coin_req += 200;
        }
    }

    public void upgrade_hold_time()
    {
        if (GameManager.manager.coins >= GameManager.manager.max_hold_coin_req)
        {
            GameManager.manager.coins -= GameManager.manager.max_hold_coin_req;
            GameManager.manager.max_hold_coin_req += 200;
        }
    }

    public void upgrade_hold_drain_rate()
    {
        if (GameManager.manager.coins >= GameManager.manager.max_hold_coin_req)
        {
            GameManager.manager.coins -= GameManager.manager.max_hold_coin_req;
            GameManager.manager.max_hold_coin_req += 200;
        }
    }
}
