using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEndInteractable : MonoBehaviour, IInteractable
{
    [SerializeField] private string levelToLoad;
    [SerializeField] private AudioClip _audioClip;
    
    public void Interact()
    {
        if (enabled == false)
            return;
        
        if (string.IsNullOrEmpty(levelToLoad))
            SceneLoader.Instance.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        else
            SceneLoader.Instance.LoadScene(levelToLoad);
        
        AudioManager.Instance.PlaySfxOneShot(_audioClip);
    }
}