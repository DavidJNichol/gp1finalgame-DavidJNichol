using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFightBlockMovement : MonoBehaviour
{
    public Rigidbody2D rigidbody;

    private void Start()
    {
        
    }

    private void Update()
    {
        rigidbody.AddForce(new Vector2(0, -5f), ForceMode2D.Impulse);
    }
}
