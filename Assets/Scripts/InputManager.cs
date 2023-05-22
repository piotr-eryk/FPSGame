using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    [SerializeField] 
    private PlayerMotor playerMotor;
    [SerializeField]
    private PlayerLook playerLook;
    [SerializeField]
    private Gun gun;
    [SerializeField]
    private ChangeWeapon changeWeapon;

    private PlayerInput playerInput;
    private PlayerInput.MovementActions movementAction;
    private Vector2 horizontalInput;
    private Vector2 mouseInput;
    private float keyInput;

    private void Awake()
    {
        playerInput = new PlayerInput();
        movementAction = playerInput.Movement;

        movementAction.HorizontalMovement.performed += ctx => horizontalInput = ctx.ReadValue<Vector2>();

        movementAction.MouseX.performed += ctx => mouseInput.x = ctx.ReadValue<float>();
        movementAction.MouseY.performed += ctx => mouseInput.y = ctx.ReadValue<float>();
        movementAction.ChooseFirstWeapon.performed += _ => changeWeapon.SwitchWeapon(0);
        movementAction.ChooseSecondWeapon.performed += _ => changeWeapon.SwitchWeapon(1);
        movementAction.ChooseThirdWeapon.performed += _ => changeWeapon.SwitchWeapon(2);
    }

    private void Update()
    {
        playerMotor.ReceiveInput(horizontalInput);
        playerLook.ReceiveInput(mouseInput);

        if (movementAction.Shoot.IsPressed())
        {
            gun.Shoot();
        }
    }

    private void OnEnable()
    {
        playerInput.Enable();
    }

    private void OnDestroy()
    {
        playerInput.Disable();
    }
}
