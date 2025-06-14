using UnityEngine;

public class PlayerAnimatorEventReceiver : MonoBehaviour
{
    [SerializeField] private PlayerSound playerSound;
    
    public void PlayFootstepSound() => playerSound.PlayFootstepSound();
}