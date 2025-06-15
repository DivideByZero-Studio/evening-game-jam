using System.Collections;
using NUnit.Framework;
using UnityEngine;

public class EyeEnemyAttack : MonoBehaviour
{
    public bool IsAttacking { get; private set; }
    [SerializeField] private Animator _animator;
    [SerializeField] private Transform _meshTransform;
    [SerializeField] private float _timeToAttack = 0.5f;
    [SerializeField] private AudioClip _hitClip;
    
    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent<PlayerSensorController>(out var playerSensorController))
        {
            var playerHealth = other.GetComponent<PlayerHealth>();
            if (playerSensorController.Visible == false && playerHealth.IsAlive && IsAttacking == false)
            {
                StartCoroutine(AttackRoutine(playerHealth));
            }
        }
    }

    private IEnumerator AttackRoutine(PlayerHealth playerHealth)
    {
        IsAttacking = true;
        
        _meshTransform.LookAt(new Vector3(playerHealth.transform.position.x, 0, playerHealth.transform.position.z));
        _animator.SetTrigger("Hit");
        
        float timer = 0;
        while (timer < _timeToAttack)
        {
            _meshTransform.LookAt(new Vector3(playerHealth.transform.position.x, 0, playerHealth.transform.position.z));
            timer += Time.deltaTime;
            yield return null;
        }
        AudioManager.Instance.PlaySfxOneShot(_hitClip, 0.5f);
        playerHealth.TakeDamage(2);
        yield return new WaitForSeconds(1f);
        IsAttacking = false;
    }
}
