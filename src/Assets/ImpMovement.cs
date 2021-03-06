﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpMovement : MonoBehaviour
{
    float speed = .05f;

    public Rigidbody2D rigidbody;
    public GameObject player;
    private Vector2 position;

    private void FixedUpdate()
    {
        if (Vector2.Distance(this.transform.position, player.transform.position) < 10)
        {            
            position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed);
            rigidbody.MovePosition(position);
        }
    }
}
