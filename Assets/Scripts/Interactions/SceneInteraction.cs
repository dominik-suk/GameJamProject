using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadInteraction : MonoBehaviour, IInteractable
{
    [Header("Serttings")]
    [SerializeField] private string sceneToLoad;
    public void Interact()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}