using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovement : MonoBehaviour
{
    public float speed;
    [HideInInspector]
    public bool bossMonster;
    public Rigidbody2D rigidbody;
    public GameObject player;
    private Vector2 position;
    private float detectionRadius = 10;

    private void Update()
    {
        if(!bossMonster)
        {
            if (Vector2.Distance(this.transform.position, player.transform.position) < detectionRadius)
            {
                position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed);
                rigidbody.MovePosition(position);
            }
        }
        else
        {
            position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed);
            rigidbody.MovePosition(position);
        }

        
    }
}
