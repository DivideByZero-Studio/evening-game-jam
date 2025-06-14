using UnityEngine;

public class PushableHands : MonoBehaviour
{
    public bool IsPushing { get; private set; }
    
    [SerializeField] private Animator _animator;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Pushable"))
        {
            _animator.SetBool("Pushing", true);
            IsPushing = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Pushable"))
        {
            _animator.SetBool("Pushing", false);
            IsPushing = false;
        }
    }
}
