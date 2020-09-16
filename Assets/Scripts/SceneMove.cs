using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMove : MonoBehaviour
{
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void moveScene(string name)
    {
        SceneManager.LoadScene(name);
        GameManager.manager.dead = false;
        GameManager.manager.isUnder = false;
    }

    public void move_to_title()
    {
        SceneManager.LoadScene("Title");
    }

    public void move_scene(string scene_name)
    {
        StartCoroutine(Load_Level_With_Transition(scene_name));
        
    }


    IEnumerator Load_Level_With_Transition(string lvl_index)
    {
        anim.SetTrigger("Start");
        yield return new WaitForSeconds(1f); // 1 second is full duration of scene transition
        SceneManager.LoadScene(lvl_index);
        GameManager.manager.dead = false;
        GameManager.manager.isUnder = false;
        GameManager.manager.started = false;
        GameManager.manager.distance_moved = 0;
        GameManager.manager.coins = 0;
        GameManager.manager.pushing_time = GameManager.manager.pushing_max;
        GameManager.manager.fatigue = GameManager.manager.max_fatigue;
        GameManager.manager.can_start = true;
        PlayerPrefs.SetFloat("current_coins", GameManager.manager.coin_in_bank);
        PlayerPrefs.SetFloat("max_fatigue", GameManager.manager.max_fatigue);
        PlayerPrefs.SetFloat("max_fatigue_cost", GameManager.manager.max_fatigue_coin_req);
        PlayerPrefs.SetFloat("fatigue_recover", GameManager.manager.fatigue_recover_multiplier);
        PlayerPrefs.SetFloat("fatigue_recover_cost", GameManager.manager.fatigue_recover_coin_req);
        PlayerPrefs.SetFloat("fatigue_drain", GameManager.manager.fatigue_drain_rate);
        PlayerPrefs.SetFloat("fatigue_drain_cost", GameManager.manager.fatigue_drain_coin_req);
        PlayerPrefs.SetFloat("max_hold", GameManager.manager.pushing_max);
        PlayerPrefs.SetFloat("max_hold_cost", GameManager.manager.max_hold_coin_req);
        PlayerPrefs.SetFloat("hold_time_drain", GameManager.manager.pushing_drain_rate);
        PlayerPrefs.SetFloat("hold_time_drain_cost", GameManager.manager.hold_drain_coin_req);
        PlayerPrefs.SetFloat("fast_duration", GameManager.manager.fast_duration);
        PlayerPrefs.SetFloat("fast_duration_cost", GameManager.manager.fast_duration_coin_req);
    }

    public void Clear_Save()
    {
        PlayerPrefs.DeleteAll();
        GameManager.manager.coin_in_bank = 0;
        GameManager.manager.highest_distance_moved = 0;
    }
}
