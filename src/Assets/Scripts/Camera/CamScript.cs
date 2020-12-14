using UnityEngine;

public class CamScript : MonoBehaviour
{
    public GameObject player;
    public Vector3 camPosition;
    private Vector3 playerPosition;

    public bool followX;

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
        if (followX)
        {
            camPosition.x = playerPosition.x;
            this.GetComponent<Camera>().fieldOfView = 120;            
        }
        else
        {
            this.GetComponent<Camera>().fieldOfView = 65;
        }
        this.transform.position = camPosition;
    }

    public void ResetPosition()
    {
        camPosition.x = 0;
        this.GetComponent<Camera>().fieldOfView = 65;
    }
}
