using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public bool IsAlive => _health > 0;
    
    [SerializeField] private Animator _animator;
    
    private int _health = 2;

    public void TakeDamage(int amount)
    {
        if (_health <= 0)
            return;
        
        _health -= amount;
        
        if (_health <= 0)
        {
            _animator.SetTrigger("Dead");
            StartCoroutine(DeadRoutine());
        }
    }

    private IEnumerator DeadRoutine()
    {
        UIController.Instance.HideScreen();
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}