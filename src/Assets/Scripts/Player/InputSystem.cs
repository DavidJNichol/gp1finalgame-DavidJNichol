using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputSystem : MonoBehaviour
{
    //public enum KeyState { Space, Left, Right, None};

    //public KeyState keyPressed;

    private void Update()
    {
        // Need these to be executed in parallel, player cant do any two of these at the same time. Hmm.
        if (!CheckNone())
        {
            CheckLeft();
            CheckSpacebar();
            CheckRight();
        }
    }

    private void FixedUpdate()
    {
        if(!CheckNone())
        {
            CheckFixedUpdateSpaceBar();
        }
    }

    public bool CheckSpacebar()
    {
        if (Input.GetKey("space"))
        {
            return true;
        }
        return false;
    }

    public bool CheckLeft()
    {
        if (Input.GetKey("left") || Input.GetKey("a"))
        {
            //keyPressed = KeyState.Left;
            return true;
        }
        return false;
    }

    public bool CheckRight()
    {
        if (Input.GetKey("right") || Input.GetKey("d"))
        {
            //keyPressed = KeyState.Right;
            return true;
        }
        return false;
    }

    public bool CheckNone()
    {
        if (!CheckSpacebar() && !CheckRight() && !CheckLeft())
            return true;
        else
            return false;
    }

    public bool CheckFixedUpdateSpaceBar()
    {
        if (Input.GetKey("space"))
        {
            return true;
        }
        return false;
    }
}
