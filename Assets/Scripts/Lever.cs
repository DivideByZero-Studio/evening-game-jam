using UnityEngine;

public class Lever : MonoBehaviour, IInteractable
{
    [SerializeField] private Animator _animator;
    [SerializeField] private GameObject _levelEndInteractable;
    [SerializeField] private GameObject _obstacle;
    

    public void Interact()
    {
        if (_obstacle == null)
            return;
        _animator.SetTrigger("Interact");
        _levelEndInteractable.AddComponent<LevelEndInteractable>();
        Destroy(_obstacle);
    }
}
