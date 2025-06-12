using UnityEngine;
using KinematicCharacterController;

public class PlayerAnimationController : MonoBehaviour
{
    [SerializeField] private KinematicCharacterMotor _characterMotor;
    [SerializeField] private Animator _animator;

    private bool _jumped;
    
    private void Update()
    {
        if (_characterMotor.GroundingStatus.IsStableOnGround && _jumped && _characterMotor.Velocity.y < 2)
        {
            _animator.SetBool("Jumped", true);
            _jumped = false;
        }
        
        if (_characterMotor.Velocity.y > 2 && !_jumped)
        {
            _jumped = true;
            _animator.SetTrigger("Jump");
            _animator.SetBool("Jumped", false);
            print("a");
        }
        
        if (Mathf.Abs(_characterMotor.Velocity.x) > 0.4 || Mathf.Abs(_characterMotor.Velocity.z) > 0.4)
        {
            _animator.SetBool("IsRunning", true);
        }
        else
        {
            _animator.SetBool("IsRunning", false);
        }
    }
}
