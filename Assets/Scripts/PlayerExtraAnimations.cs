using System.Collections;
using UnityEditor;
using UnityEngine;

public class PlayerExtraAnimations : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private PlayerSensorController _playerSensorController;
        
    public void WakeUp()
    {
        StartCoroutine(WakeUpAnimationRoutine());
    }

    private IEnumerator WakeUpAnimationRoutine()
    {
        _playerMovement.enabled = false;
        _playerSensorController.enabled = false;
        _animator.SetTrigger("WakeUp");
        yield return new WaitForSeconds(8);
        _playerMovement.enabled = true;
        _playerSensorController.enabled = true;
    }

    public void LayDown()
    {
        _animator.SetTrigger("LayDown");
        _playerMovement.enabled = false;
        _playerSensorController.enabled = false;
    }
}
