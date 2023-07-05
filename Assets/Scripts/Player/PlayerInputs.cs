using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputs : MonoBehaviour
{
    private Actions _actions;

    public delegate void OnMove(float value);
    public OnMove onMove;

    public delegate void OnRotate(float value);
    public OnMove onRotate;

    private void Awake()
    {
        _actions = new Actions();
        _actions.Enable();
        _actions.FileHandle.Save.performed += Save;
        _actions.FileHandle.Load.performed += Load;
    }

    private void Update()
    {
        onMove(_actions.Player.Move.ReadValue<float>());
        onRotate(_actions.Player.Rotate.ReadValue<float>());
    }

    private void Save(InputAction.CallbackContext context)
    {
        SaveManager.instance.Save();
    }

    private void Load(InputAction.CallbackContext context)
    {
        SaveManager.instance.Load();
    }
}
