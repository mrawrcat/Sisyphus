using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeUI : MonoBehaviour
{
    //Attach an Image you want to fade in the GameObject's Inspector
    public Image m_Image;

    //Use this to tell if the toggle returns true or false
    public bool m_Fading;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //If the toggle returns true, fade in the Image
        if (m_Fading == true)
        {
            //Fully fade in Image (1) with the duration of 1
            m_Image.CrossFadeAlpha(1, 1.0f, false);
            //m_Text.CrossFadeAlpha(1, 0.5f, false);
        }
        //If the toggle is false, fade out to nothing (0) the Image with a duration of 1
        if (m_Fading == false)
        {
            m_Image.CrossFadeAlpha(0, 1.0f, false);
            //m_Text.CrossFadeAlpha(0, 0.5f, false);
        }
    }

    public void toggle_fade()
    {
        m_Fading = !m_Fading;
    }

}
