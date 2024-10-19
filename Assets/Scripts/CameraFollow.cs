using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // Reference to the player's transform

    void Start()
    {
        
    }
    void LateUpdate()
    {
        transform.position = new Vector3(transform.position.x,transform.position.y,player.transform.position.z - 4.94f);
    }
}
