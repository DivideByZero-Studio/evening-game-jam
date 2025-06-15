using UnityEngine;

public class AwakeAnimation : MonoBehaviour 
{
    [SerializeField] private PlayerExtraAnimations _playerExtraAnimations;

    private void Start()
    {
        _playerExtraAnimations.WakeUp();
    }
}
