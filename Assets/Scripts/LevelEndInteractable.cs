using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEndInteractable : MonoBehaviour, IInteractable
{
    [SerializeField] private string levelToLoad;
    
    public void Interact()
    {
        if (string.IsNullOrEmpty(levelToLoad))
            SceneLoader.Instance.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        else
            SceneLoader.Instance.LoadScene(levelToLoad);
    }
}