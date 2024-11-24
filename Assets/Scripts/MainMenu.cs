using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    [Header("Settings")]
    [SerializeField] private string firstSceneName;
    public void StartGame(){
        SceneManager.LoadScene(firstSceneName);
    }
    public void ExitGame(){
        Application.Quit();
    }
}