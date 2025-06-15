using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private TriggerCollider interactableCheckTrigger;

    private IInteractable _targetInteractable;
    
    private void Awake()
    {
        interactableCheckTrigger.TriggerEnter += col =>
        {
            if (col.TryGetComponent(out IInteractable interactable))
            {
                _targetInteractable = interactable;
                _targetInteractable.ShowHint();
            }
        };
        interactableCheckTrigger.TriggerExit += col =>
        {
            if (col.TryGetComponent(out IInteractable interactable))
            {
                if (_targetInteractable == interactable)
                    _targetInteractable = null;
                interactable.HideHint();
            }
        };
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && _targetInteractable != null)
        {
            _targetInteractable.Interact();
        }
    }
}