using UnityEngine;

public class PushableHands : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Pushable"))
        {
            _animator.SetTrigger("PushStart");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Pushable"))
        {
            _animator.SetTrigger("PushEnd");
        }
    }
}
