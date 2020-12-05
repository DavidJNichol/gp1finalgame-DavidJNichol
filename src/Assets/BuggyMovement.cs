using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuggyMovement : MonoBehaviour
{
    Vector2 pos;
    float speed = 5f;

    private float xMaxBound = 5.658f;
    private float xMinBound = -6.27f;

    public BuggyCollision buggyCollision;

    // Start is called before the first frame update
    void Start()
    {
        pos = new Vector2(this.transform.position.x, this.transform.position.y);
    }

    //private void Update()
    //{
        

    //    //pos.x += speed * Time.deltaTime;
    //    //this.transform.position = pos;

    //    //if (this.transform.position.x > xMaxBound || this.transform.position.x < xMinBound)
    //    //{
    //    //    speed *= -1;
    //    //}
    //}

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if(collision.collider.gameObject.tag == "Ground")
    //    {
    //        Debug.Log("Turn Around");
    //        speed *= -1;
    //    }
    //}
}
