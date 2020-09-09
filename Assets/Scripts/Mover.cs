using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{

    public GameObject spiker;
    public float speed;
    public float time_to_stomp;
    public float time_to_stomp_time;
    public Transform currentpoint;
    public Transform[] points;
    public int pointselection;

    // Start is called before the first frame update
    void Start()
    {
        currentpoint = points[pointselection];
        time_to_stomp = Random.Range(5, 20);
        time_to_stomp_time = time_to_stomp;
    }

    // Update is called once per frame
    void Update()
    {
        if(time_to_stomp_time > 0)
        {
            time_to_stomp_time -= Time.deltaTime;
        }

        if(time_to_stomp_time < 0)
        {
            movewall();
        }
    }

    void movewall()
    {
        spiker.transform.position = Vector3.MoveTowards(spiker.transform.position, currentpoint.position, speed * Time.deltaTime);
        if (spiker.transform.position == currentpoint.position)
        {
            pointselection++;
            if (pointselection == points.Length)
            {
                pointselection = 0;

            }
            if(pointselection == 1)
            {
                time_to_stomp_time = time_to_stomp;
            }
            currentpoint = points[pointselection];
        }
    }
}
