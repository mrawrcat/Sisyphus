using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{

    /*
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Player")
        {
            gameObject.SetActive(false);

            if (collision.collider.GetComponent<PlayerControl>().hiding)
            {
                Debug.Log("bomb hit rock (player but hiding)");
            }
            else
            {
                GameManager.manager.dead = true;
                Debug.Log("bomb hit player");
            }
        }

        if(collision.collider.tag == "Tilemap")
        {
            Debug.Log("bomb hit ground");
            gameObject.SetActive(false);
        }
    }

    */
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            gameObject.SetActive(false);

            if (collision.GetComponent<PlayerControl>().hiding)
            {
                Debug.Log("bomb hit rock (player but hiding)");
            }
            else
            {
                GameManager.manager.dead = true;
                Debug.Log("bomb hit player");
            }
        }

        if(collision.tag == "Tilemap")
        {
            Debug.Log("bomb hit ground");
            gameObject.SetActive(false);
        }
    }
}
