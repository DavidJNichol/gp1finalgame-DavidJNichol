using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBreakable 
{
    List<GameObject> sceneObjects { get; set; }
    List<GameObject> objectsToRemove { get; set; }

    int amountOfObjects { get; set; }

    void PopulateSceneList();

    void Destroy();
}
