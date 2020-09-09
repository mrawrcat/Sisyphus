using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalk : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public float LeftX, RightX;
    // Start is called before the first frame update
    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        Walk();
        if (GameManager.manager.started)
        {
            //rb2d.velocity = new Vector2(0, rb2d.velocity.y);
        }
    }

    public void Walk()//this script governs the player's ability to walk back to original position when pushed by terrain
    {
        if (transform.position.x < LeftX)
        {
            rb2d.velocity = new Vector2(5, rb2d.velocity.y);
            Debug.Log("behind left");
        }
        else
        {
            rb2d.velocity = new Vector2(0, rb2d.velocity.y);
        }
    }
}
