using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadInteraction : MonoBehaviour, IInteractable
{
    [Header("Serttings")]
    [SerializeField] private GameObject sceneToLoad;
    public void Interact()
    {
        SceneManager.LoadScene(sceneToLoad.name);
    }
}