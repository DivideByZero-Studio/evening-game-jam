using UnityEngine;

public class PlayerSensorController : MonoBehaviour
{
    public bool Visible { get; private set; }
    public bool Audible { get; private set; }

    [SerializeField] private Animator _animator;
    [SerializeField] private PushableHands _pushableHands;
    [SerializeField] private PlayerHealth _playerHealth;
    private void Update()
    {
        if (_pushableHands.IsPushing && (Visible || Audible) || _playerHealth.IsAlive == false)
        {
            Visible = false;
            _animator.SetBool("EyesClosed", false);
            UIController.Instance.OpenEyes();
            
            Audible = false; 
            _animator.SetBool("EarsClosed", false);
        }
        else
        {
            ProcessEyes();
            ProcessEars();
        }
    }

    private void ProcessEyes()
    {
        if (Audible)
            return;
        
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            Visible = false;
            _animator.SetBool("EyesClosed", false);
            UIController.Instance.OpenEyes();
        }
        
        if (!Input.GetKeyDown(KeyCode.Mouse0))
            return;

        Visible = true;
        _animator.SetBool("EyesClosed", true);
        UIController.Instance.CloseEyes();
    }

    private void ProcessEars()
    {
        if (Visible)
            return;
        
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            Audible = false; 
            _animator.SetBool("EarsClosed", false);
            AudioManager.Instance.SetNormalSnapshot(0.3f);
        }
        
        if (!Input.GetKeyDown(KeyCode.Mouse1))
            return;

        Audible = true;
        _animator.SetBool("EarsClosed", true);
        AudioManager.Instance.SetEarsClosedSnapshot(0.3f);
    }
    
}
