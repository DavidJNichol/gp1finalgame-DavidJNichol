using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpCollision : CollidableObject
{
    private void Start()
    {
        childClassTransform = this.transform;
        sceneObject = Object.Imp;
    }


}
