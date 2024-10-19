using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public Transform player;  // Player to follow
    public float rotationSpeed = 90f;  // Rotation step in degrees
    public Transform background;

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

        AlignBackgroundWithCamera();

    }
    void AlignBackgroundWithCamera()
    {
        // Ensure the background plane is always aligned to face the camera
        background.rotation = Quaternion.LookRotation(transform.forward, Vector3.up);
    }
}
