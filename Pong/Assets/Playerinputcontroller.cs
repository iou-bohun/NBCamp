using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Playerinputcontroller : TopDownCharacterController
{
    public void OnMove(InputValue inputValue)
    {
        Debug.Log("move" + inputValue.ToString());
        Vector2 moveInput = inputValue.Get<Vector2>().normalized;
        CallMoveEvent(moveInput);
    }
}
