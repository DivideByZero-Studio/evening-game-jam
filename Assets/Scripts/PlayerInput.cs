using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public InputActions InputActions { get; private set; }

    private void Awake()
    {
        InputActions = new InputActions();
        InputActions.Enable();
        InputActions.Player.Enable();
    }
}
