using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuggyCollision : CollidableObject
{
    //public GemScript gems;
    private void Start()
    {
        childClassTransform = this.transform;
        sceneObject = Object.Buggy; // From CollidableObject
    }

}
