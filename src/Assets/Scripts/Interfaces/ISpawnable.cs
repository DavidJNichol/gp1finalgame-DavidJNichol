using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISpawnable
{
    List<GameObject> sceneObjects { get; set; }

    int amountOfObjects { get; set; }

    void PopulateScene();
}
