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



    [Header("Game/Player Status")]
    public bool dead;
    public bool movingReset;
    public bool isUnder;
    public bool started;

    public float pushed_rock;
    public float pushed_rock_timer;
    public float pushing_time;
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
    }
}
