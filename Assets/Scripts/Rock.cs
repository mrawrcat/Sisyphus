using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    public float speed;
    public float touch;
    public bool touching_player;
    private Rigidbody2D rb2d;
    private Quest_Giver quest_giver;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        quest_giver = FindObjectOfType<Quest_Giver>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!touching_player)
        {
            rb2d.velocity = new Vector2(speed, rb2d.velocity.y);
        }
        else if (GameManager.manager.dead)
        {
            rb2d.velocity = new Vector2(speed, rb2d.velocity.y);
        }

        if (touching_player)
        {
            if (GameManager.manager.started)
            {
                GameManager.manager.pushing_time -= GameManager.manager.pushing_drain_rate * Time.deltaTime;
            }
        }
    }

    public void Reset_Boulder()
    {
        rb2d.velocity = Vector2.zero;
        transform.position = new Vector2(-3, -4);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Player")
        {
            touching_player = true;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            touching_player = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            touching_player = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Is_Under")
        {
            GameManager.manager.isUnder = true;
            GameManager.manager.coin_in_bank += GameManager.manager.coins;
            PlayerPrefs.SetFloat("current_coins", GameManager.manager.coin_in_bank);
            if (GameManager.manager.distance_moved > GameManager.manager.highest_distance_moved)
            {
                GameManager.manager.highest_distance_moved = GameManager.manager.distance_moved;
                PlayerPrefs.SetFloat("highest_distance", GameManager.manager.highest_distance_moved);
            }
            quest_giver.Talk_to_Quest_Giver();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            touching_player = false;
        }
    }
}
