using System.Collections;
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

    //Attach an Image you want to fade in the GameObject's Inspector
    public Image m_Image;
    //Use this to tell if the toggle returns true or false
    public bool m_Fading;

    public Animator anim;
    private ObjectPoolNS pool;
    // Start is called before the first frame update
    void Start()
    {
        //reviveButtonRect.anchoredPosition = new Vector2(0, 500);
        pool = GameObject.Find("Tilemap").GetComponent<ObjectPoolNS>();
        anim = GetComponentInParent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        distance.text = GameManager.manager.distance_moved.ToString("F0") + " m";
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


        if (m_Fading == true)
        {
            //Fully fade in Image (1) with the duration of 1
            m_Image.CrossFadeAlpha(1, 1.0f, false);
        }
        //If the toggle is false, fade out to nothing (0) the Image with a duration of 1
        if (m_Fading == false)
        {
            m_Image.CrossFadeAlpha(0, 1.0f, false);
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
        yield return new WaitForSeconds(.5f);
        anim.SetTrigger("End");
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
        GameManager.manager.pushed_rock_timer = 0;
        GameManager.manager.pushing_time = 3;
        GameManager.manager.distance_moved = 0;
        pool.tileheight = 15;
        //player_death.InstantMove();
        

    }
}
