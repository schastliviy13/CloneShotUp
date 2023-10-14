using System;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    //��������� ����� InputAction �� �� ������������ ����������� ������ ������� ����� ������, � �� � Update
    //�������������� ������� ��������
    public static GameInput Instance { get; private set; }

    public event EventHandler OnPressAction;

    private PlayerInputActions playerInputActions;

    private void Awake()
    {
        Instance = this;
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
        playerInputActions.Player.Press.performed += Press_performed;
    }

    private void Press_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnPressAction?.Invoke(this, EventArgs.Empty);
    }
}
