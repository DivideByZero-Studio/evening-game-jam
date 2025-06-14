using System.Collections;
using NUnit.Framework;
using UnityEngine;

public class EyeEnemyAttack : MonoBehaviour
{
    public bool IsAttacking { get; private set; }
    [SerializeField] private Animator _animator;
    [SerializeField] private Transform _meshTransform;
    
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
        
        _meshTransform.LookAt(new Vector3(0, 0, playerHealth.transform.position.z));
        _animator.SetTrigger("Hit");

        float timer = 0;
        while (timer < 0.5f)
        {
            _meshTransform.LookAt(new Vector3(0, 0, playerHealth.transform.position.z));
            timer += Time.deltaTime;
            yield return null;
        }
        
        playerHealth.TakeDamage(2);
        yield return new WaitForSeconds(1f);
        IsAttacking = false;
    }
}
