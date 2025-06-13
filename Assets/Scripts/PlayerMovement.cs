using KinematicCharacterController.Examples;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerCharacterController characterController;
    
    private Vector2 inputDirection;
    private PlayerInput playerInput;

    private void Update()
    {
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