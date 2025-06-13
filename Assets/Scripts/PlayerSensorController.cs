using UnityEngine;

public class PlayerSensorController : MonoBehaviour
{
    public bool Visible { get; private set; }
    public bool Audible { get; private set; }

    [SerializeField] private Animator _animator;
    
    private void Update()
    {
        ProcessEyes();
        ProcessEars();
    }

    private void ProcessEyes()
    {
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
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            Audible = false; 
            _animator.SetBool("EarsClosed", false);
            
        }
        
        if (!Input.GetKeyDown(KeyCode.Mouse1))
            return;

        Audible = true;
        _animator.SetBool("EarsClosed", true);

        
    }
    
}
