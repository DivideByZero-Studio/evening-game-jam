using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public bool IsAlive => _health > 0;
    
    [SerializeField] private Animator _animator;
    
    private PlayerSound _playerSound;
    private int _health = 2;

    private void Awake()
    {
        _playerSound = GetComponent<PlayerSound>();
    }

    public void TakeDamage(int amount)
    {
        if (_health <= 0)
            return;
        
        _playerSound.PlayGotDamagedSound();
        
        _health -= amount;
        if (_health <= 0)
        {
            AudioManager.Instance.SetNormalSnapshot(0.3f);
            _playerSound.PlayDeathSound();
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