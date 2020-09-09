using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform focus;
    public Vector2 offset;
    void Update()
    {
        transform.position = focus.position + new Vector3(offset.x, offset.y, 0);
    }
}
