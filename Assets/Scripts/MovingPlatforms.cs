using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Vector3 direction = Vector3.left; // Direction of movement (default is left)
    public float speed = 2f; // Speed of movement

    void Update()
    {
        // Move the platform in the specified direction
        transform.position += direction.normalized * speed * Time.deltaTime;
    }
}
