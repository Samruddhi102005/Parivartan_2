

using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Menu : MonoBehaviour
{
    // Method for the Start button
    public void StartGame()
    {
        // Load the game scene (replace "GameScene" with your scene name)
        SceneManager.LoadScene("GameScene");
    }

    // Method for the Options button
    public void OpenOptions()
    {
        // Logic to open options (could be a separate panel in the UI)
        Debug.Log("Options opened.");
    }

    // Method for the Exit button
    public void ExitGame()
    {
        // Exit the game (will work only in the built application)
        Debug.Log("Game exited.");
        Application.Quit();
    }
}
