using UnityEngine;

public class BabaikaPatrol : MonoBehaviour
{
    [SerializeField] private EyeEnemyAttack _enemyAttack;
    [SerializeField] private Animator _animator;
    
    [SerializeField] private Transform _leftPoint;
    [SerializeField] private Transform _rightPoint;

    [SerializeField] private float _speed;

    private Vector3 _currentPoint;

    private void Start()
    {
        _currentPoint = new Vector3(transform.position.x, transform.position.y, _leftPoint.position.z);
    }

    private void Update()
    {
        Patrol();
    }
    
    private void Patrol()
    {
        if (_enemyAttack.IsAttacking)
            return;
        
        transform.position = Vector3.MoveTowards(transform.position, _currentPoint, _speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, _currentPoint) <= 0.1f)
        {
            if (Mathf.Approximately(_currentPoint.z, _leftPoint.position.z))
            {
                _animator.SetBool("MovingLeft", false);
                _animator.SetBool("MovingRight", true);
                _currentPoint = new Vector3(transform.position.x, transform.position.y, _rightPoint.position.z);
            }
            else
            {
                _animator.SetBool("MovingLeft", true);
                _animator.SetBool("MovingRight", false);
                _currentPoint = _currentPoint = new Vector3(transform.position.x, transform.position.y, _leftPoint.position.z);
            }
        }
    }
    
}