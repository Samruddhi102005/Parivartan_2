using UnityEngine;
using System.Collections.Generic;

public class PlatformManager : MonoBehaviour
{
    public GameObject platformPrefab;   // Assign your platform prefab here
    public float platformLength = 10f;  // Length of each platform
    public int initialPlatforms = 5;    // Number of platforms to initially spawn
    public float safeZone = 15f;        // Distance before a platform is considered off-screen
    private Transform playerTransform;  // Reference to the player's transform
    private float spawnZ = 0f;          // Initial Z-position for platform spawning
    private List<GameObject> activePlatforms = new List<GameObject>(); // List of active platforms

    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform; // Assuming player has "Player" tag

        // Spawn initial platforms
        for (int i = 0; i < initialPlatforms; i++)
        {
            SpawnPlatform();
        }
    }

    private void Update()
    {
        // Check if we need to spawn and reset platforms based on player's position
        if (playerTransform.position.z - safeZone > (spawnZ - initialPlatforms * platformLength))
        {
            SpawnPlatform();
            ResetPlatform();
        }
    }

    private void SpawnPlatform()
    {
        // Create a new platform and position it along the Z-axis
        GameObject platform = Instantiate(platformPrefab, new Vector3(0, 0, spawnZ), Quaternion.identity);
        activePlatforms.Add(platform); // Add to active platforms list
        spawnZ += platformLength;      // Increment the spawnZ for the next platform
    }

    private void ResetPlatform()
    {
        // If a platform has moved out of the player's view, move it to the end
        GameObject platformToReset = activePlatforms[0]; // Get the first platform in the list
        activePlatforms.RemoveAt(0); // Remove it from the front of the list
        platformToReset.transform.position = new Vector3(0, 0, spawnZ); // Move it to the new position
        activePlatforms.Add(platformToReset); // Add it to the end of the list
        spawnZ += platformLength; // Update spawnZ for next platform
    }
}
