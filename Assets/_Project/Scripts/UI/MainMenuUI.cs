using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    [Header("Scene loading")]
    [Tooltip("Scene name to load when Start is pressed (e.g. Boot or Home_Interior). Must be in Build Settings.")]
    [SerializeField] private string firstSceneName = "Boot";

    public void OnStartClicked()
    {
        Debug.Log("Start clicked");
        if (string.IsNullOrEmpty(firstSceneName))
        {
            Debug.LogWarning("MainMenuUI: First Scene Name is not set in the Inspector.");
            return;
        }
        SceneManager.LoadScene(firstSceneName);
    }

    public void OnQuitClicked()
    {
                Debug.Log("Quit clicked");

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}