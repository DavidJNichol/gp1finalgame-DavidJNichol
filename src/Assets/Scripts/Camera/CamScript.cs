using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamScript : MonoBehaviour
{
    public GameObject player;

    private Vector3 camPosition;

    private Vector3 playerPosition;

    // Start is called before the first frame update
    void Start()
    {        
        camPosition = playerPosition;

        camPosition.z -= 10;
    }

    // Update is called once per frame
    void Update()
    {
        playerPosition = player.transform.position;
        camPosition.y = playerPosition.y;
        this.transform.position = camPosition;
    }
}
