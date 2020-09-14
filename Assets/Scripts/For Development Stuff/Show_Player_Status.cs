using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Show_Player_Status : MonoBehaviour
{
    public Text pushing_or_not;
    private PlayerControl player;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<PlayerControl>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.hiding)
        {
            pushing_or_not.text = "Hiding";

        }
        else
        {
            pushing_or_not.text = "Rolling";
        }
    }
}
