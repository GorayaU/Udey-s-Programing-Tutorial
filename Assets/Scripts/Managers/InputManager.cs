using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public static class InputManager
{
    private static Controls _controls;

    public static void Init(Player myPlayer, MagTracker mag)
    {
        _controls = new Controls();

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;

        _controls.Game.Movement.performed += ctx => 
        {
            myPlayer.SetMovementDirection(ctx.ReadValue<Vector3>());
        };
        _controls.Game.Look.performed += ctx =>
        {
            myPlayer.SetLookDirection(ctx.ReadValue<Vector2>());
        };
        _controls.Game.Shoot.performed += ctx =>
        {
            myPlayer.Shoot();
        };
        _controls.Game.Reload.performed += ctx =>
        {
            mag.Reload();
        };
        

        _controls.Permanent.Enable();
    }
    public static void GameMode()
    {
        _controls.Game.Enable();
        _controls.UI.Disable();
    }

    public static void UIMode()
    {
        _controls.Game.Disable();
        _controls.UI.Enable();
    }

}
