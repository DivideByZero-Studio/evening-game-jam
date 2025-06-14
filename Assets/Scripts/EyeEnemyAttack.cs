using System.Collections;
using UnityEngine;

public class EyeEnemyAttack : MonoBehaviour
{
    public bool IsAttacking { get; private set; }
    [SerializeField] private Animator _animator;

    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent<PlayerSensorController>(out var playerSensorController))
        {
            var playerHealth = other.GetComponent<PlayerHealth>();
            if (playerSensorController.Visible == false && playerHealth.IsAlive)
            {
                StartCoroutine(AttackRoutine(playerHealth));
            }
        }
    }

    private IEnumerator AttackRoutine(PlayerHealth playerHealth)
    {
        IsAttacking = true;
        
        _animator.SetTrigger("Hit");
        playerHealth.TakeDamage(2);
        yield return new WaitForSeconds(1f);
        IsAttacking = false;
    }
}
