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
        if (other.TryGetComponent<PlayerSensorController>(out var playerSensorController))
        {
            var playerHealth = other.GetComponent<PlayerHealth>();
            if (playerSensorController.Audible == false && playerHealth.IsAlive)
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
        var direction = playerHealth.transform.position - _meshTransform.position;
        direction.y = 0;
        direction.z = 0;
        _meshTransform.localRotation = Quaternion.LookRotation(direction, Vector3.up);
        _animator.SetTrigger("Hit");
        _projectile.SetActive(true);
        
        float timer = 0;
        while (timer < _timeToAttack)
        {
            direction = playerHealth.transform.position - _meshTransform.position;
            direction.y = 0;
            direction.z = 0;
            _meshTransform.localRotation = Quaternion.LookRotation(direction, Vector3.up);
            timer += Time.deltaTime;
            yield return null;
        }
        
        playerHealth.TakeDamage(1);
        yield return new WaitForSeconds(0.2f);
        _projectile.SetActive(false);
    }
}
