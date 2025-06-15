using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        StartCoroutine(LayDownAnimationRoutine());
    }

    private IEnumerator LayDownAnimationRoutine()
    {
        _animator.SetTrigger("LayDown");
        _playerMovement.Disable();
        _playerMovement.enabled = false;
        _playerSensorController.Disable();
        _playerSensorController.enabled = false;
        yield return new WaitForSeconds(6);
        SceneLoader.Instance.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
