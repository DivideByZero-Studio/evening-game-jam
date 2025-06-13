using UnityEngine;

public class PushableHands : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Pushable"))
        {
            _animator.SetBool("Pushing", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Pushable"))
        {
            _animator.SetBool("Pushing", false);
        }
    }
}
