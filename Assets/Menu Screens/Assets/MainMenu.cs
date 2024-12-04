using UnityEngine;
using UnityEngine.SceneManagement;  // For loading scenes
using UnityEngine.UI;  // For accessing UI elements

public class MainMenu : MonoBehaviour
{
    // This function will start the game
    public void PlayGame()
    {
        // Load the next scene (usually the game scene).
        // Here, we assume the game scene is called "GameScene".
        SceneManager.LoadScene("Game");
    }

    // This function will exit the game
    public void ExitGame()
    {
        // If running in the editor, stop the play mode
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            // If in a build, quit the application
            Application.Quit();
#endif
    }
}
