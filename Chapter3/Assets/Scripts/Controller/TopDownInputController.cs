using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TopDownInputController : TopDownCharacterController
{
    private Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;
    }


    public void OnMove(InputValue value) //WASD��ǲ
    {
        Vector2 direction = value.Get<Vector2>().normalized;
        CallMoveEvent(direction);
    }
    public void OnLook(InputValue value) //���콺�� ScreenPoin Position
    {
        Vector2 newAim = value.Get<Vector2>();
        Vector2 worldPos = _camera.ScreenToWorldPoint(newAim);
        newAim = (worldPos - (Vector2)transform.position).normalized; //�������

        if(newAim.magnitude > .9f)
        {
            CallLookEvent(newAim);
        }
    }
}
