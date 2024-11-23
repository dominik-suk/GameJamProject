using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    [Header("Settings")]
    [SerializeField] private string pauseMenuSceneName;
    public void StartGame(){
        SceneManager.LoadScene(pauseMenuSceneName);
    }
    public void ExitGame(){
        Application.Quit();
    }
}