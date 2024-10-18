using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public Transform player;  // Player to follow
    public float rotationSpeed = 90f;  // Rotation step in degrees

    private int currentViewAngle = 0;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))  // Rotate left
        {
            RotateCamera(-90);
        }
        else if (Input.GetKeyDown(KeyCode.E))  // Rotate right
        {
            RotateCamera(90);
        }
    }

    void RotateCamera(int angle)
    {
        currentViewAngle += angle;
        currentViewAngle %= 360;  // Keep the angle within 0-360 degrees

        // Rotate the camera around the player
        transform.RotateAround(player.position, Vector3.up, angle);
    }
}
