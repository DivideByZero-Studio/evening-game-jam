using KinematicCharacterController.Examples;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerCharacterController characterController;
    [SerializeField] private PlayerHealth _playerHealth;
    
    private Vector2 inputDirection;
    private PlayerInput playerInput;

    public void Disable()
    {
        var characterInputs = new PlayerCharacterInputs
        {
            MoveAxisRight = 0f,
            MoveAxisForward = 0f,
            JumpDown = false,
        };

        characterController.SetInputs(ref characterInputs);
    }
    
    private void Update()
    {
        if (!_playerHealth.IsAlive)
        {
            var characterInputs = new PlayerCharacterInputs
            {
                MoveAxisRight = 0f,
                MoveAxisForward = 0f,
                JumpDown = false,
            };

            characterController.SetInputs(ref characterInputs);
        }
        else
            HandleCharacterInput();
    }
    
    private void HandleCharacterInput()
    {
        var characterInputs = new PlayerCharacterInputs
        {
            MoveAxisRight = -Input.GetAxisRaw("Vertical"),
            MoveAxisForward = Input.GetAxisRaw("Horizontal"),
            JumpDown = Input.GetKeyDown(KeyCode.Space),
        };

        characterController.SetInputs(ref characterInputs);
    }
}