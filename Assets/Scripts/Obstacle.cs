using UnityEngine;

public class Obstacle : MonoBehaviour, IInteractable
{
    [SerializeField] private AudioClip _notEnterSound;
    public void Interact()
    {
        AudioManager.Instance.PlaySfxOneShot(_notEnterSound);
    }
    
    public void ShowHint()
    {

    }

    public void HideHint()
    {
        
    }
}
