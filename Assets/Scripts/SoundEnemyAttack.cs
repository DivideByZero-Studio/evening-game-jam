using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

public class SoundEnemyAttack : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private float _attackCooldown;
    [SerializeField] private Transform _meshTransform;

    [SerializeField] private GameObject _projectile;
        
    [SerializeField] private float _timeToAttack;
    
    private Transform _target;

    private float _timer;

    private void Update()
    {
        _timer += Time.deltaTime;
    }
    
    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent(out PlayerSensorController playerSensorController))
        {
            var direction = playerSensorController.transform.position - _meshTransform.position;
            direction.x = 0.1f;
            var lookRotation = Quaternion.LookRotation(direction) * Quaternion.Euler(-90, 0, 0);
            var newRotation = lookRotation.eulerAngles;
            newRotation.y = 0;
            newRotation.x *= -Mathf.Sign(Mathf.Abs(_meshTransform.position.z) - Mathf.Abs(playerSensorController.transform.position.z));
            _meshTransform.localRotation = Quaternion.Euler(newRotation);
            
            var playerHealth = other.GetComponent<PlayerHealth>();
            if (!playerSensorController.Audible && playerHealth.IsAlive)
            {
                if (_timer >= _attackCooldown)
                {
                    _timer = 0;
                    StartCoroutine(AttackRoutine(playerHealth));
                }
            }
        }
    }
    
    private IEnumerator AttackRoutine(PlayerHealth playerHealth)
    {
        _animator.SetTrigger("Hit");
        _projectile.SetActive(true);

        yield return new WaitForSeconds(_timeToAttack);
        
        playerHealth.TakeDamage(1);
        yield return new WaitForSeconds(0.2f);
        _projectile.SetActive(false);
    }
}
