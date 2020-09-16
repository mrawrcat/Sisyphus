using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Title_Text_Setter : MonoBehaviour
{
    public Text current_coins;
    public Text current_highscore;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.manager.coin_in_bank = PlayerPrefs.GetFloat("current_coins", 0);
        GameManager.manager.highest_distance_moved = PlayerPrefs.GetFloat("highest_distance", 0);
        current_coins.text = GameManager.manager.coin_in_bank.ToString("F0") + " Coins";
        current_highscore.text = GameManager.manager.highest_distance_moved.ToString("F0") + "M";


    }

    
}
