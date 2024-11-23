using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private string mainMenuSceneName;
    [SerializeField] private GameObject controlsPanel;
    private void OnEnable() {
        Time.timeScale = 0;
    }
    private void OnDisable() {
        Time.timeScale = 1;
    }
    public void OpenMainMenu(){
        SceneManager.LoadScene(mainMenuSceneName);
    }
    public void ShowControlsPanel(){
        controlsPanel.SetActive(true);
    }
}
