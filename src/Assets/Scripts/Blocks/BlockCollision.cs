using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockCollision : CollidableObject
{
    public bool isGemBlock;

    private void Start()
    {
        sceneObject = SpawnedObjectType.Block;

        if(isGemBlock)
        {
            childClassTransform = this.transform; // Activates the ability to drop gems
        }
    }
}
