using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuggyCollision : CollidableObject
{
    public GameObject player;
    private void Start()
    {
        childClassTransform = this.transform;
        sceneObject = SpawnedObjectType.Buggy; // From CollidableObject
    }
}
