using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovement : MonoBehaviour
{
    public float speed;

    public Rigidbody2D rigidbody;
    public GameObject player;
    private Vector2 position;

    private void Update()
    {
        if (Vector2.Distance(this.transform.position, player.transform.position) < 10)
        {
            position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed);
            rigidbody.MovePosition(position);
        }
    }
}
