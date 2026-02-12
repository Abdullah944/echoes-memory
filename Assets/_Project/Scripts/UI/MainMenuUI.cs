//? -------- what / why --------
//? This file is the main menu controller: handles Start and Quit button clicks.
//? We have it so the player can launch the first scene or exit the game from the start menu.

using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    //? -------- scene loading -------- Inspector setting for which scene to load on Start.

    [Header("Scene loading")]
    [Tooltip("Scene name to load when Start is pressed (e.g. Boot or Home_Interior). Must be in Build Settings.")]
    [SerializeField] private string firstSceneName = "Boot";

    //? -------- Unity lifecycle / public API -------- Button callbacks.

    //? Called when Start button is clicked; loads the scene named in firstSceneName.
    public void OnStartClicked()
    {
        if (string.IsNullOrEmpty(firstSceneName))
        {
            Debug.LogWarning("MainMenuUI: First Scene Name is not set in the Inspector.");
            return;
        }
        SceneManager.LoadScene(firstSceneName);
    }

    //? Called when Quit button is clicked; exits play mode in Editor or quits the application in build.
    public void OnQuitClicked()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}