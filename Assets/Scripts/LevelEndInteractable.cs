using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEndInteractable : MonoBehaviour, IInteractable
{
    [SerializeField] private string levelToLoad;
    [SerializeField] private AudioClip _audioClip;
    [SerializeField] private HintInteractable _hintInteractable;
    
    public void Interact()
    {
        if (enabled == false)
            return;
        
        if (string.IsNullOrEmpty(levelToLoad))
            SceneLoader.Instance.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        else
            SceneLoader.Instance.LoadScene(levelToLoad);
        
        AudioManager.Instance.PlaySfxOneShot(_audioClip);
        _hintInteractable.HideWithParticles();
        enabled = false;
    }
    
    public void ShowHint()
    {
        if (enabled == false)
            return;
        _hintInteractable.Show();
    }

    public void HideHint()
    {
        _hintInteractable.Hide();
    }
}