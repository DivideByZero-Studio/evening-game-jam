using UnityEngine;

public class Lever : MonoBehaviour, IInteractable
{
    [SerializeField] private Animator _animator;
    [SerializeField] private LevelEndInteractable _levelEndInteractable;
    [SerializeField] private GameObject _obstacle;
    [SerializeField] private AudioClip _audioClip;
    
    [SerializeField] private HintInteractable _hintInteractable;
    
    private void Start()
    {
        _levelEndInteractable.enabled = false;
    }
    
    public void Interact()
    {
        if (_obstacle == null)
            return;
        _animator.SetTrigger("Interact");
        AudioManager.Instance.PlaySfxOneShot(_audioClip);
        _hintInteractable.HideWithParticles();
        _levelEndInteractable.enabled = true;
        Destroy(_obstacle);
    }

    public void ShowHint()
    {
        _hintInteractable.Show();
    }

    public void HideHint()
    {
        _hintInteractable.Hide();
    }
}
