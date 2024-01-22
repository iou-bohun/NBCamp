using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownCharacterController : MonoBehaviour
{
    public event Action<Vector2> OnMoveEvent;

    public void CallMoveEvent(Vector2 direction)
    {
        if (OnMoveEvent == null)
        {
            Debug.Log("Null");
        }
        OnMoveEvent?.Invoke(direction);
    }

    public void CallEvent(Vector2 dir)
    {
        if(OnMoveEvent == null)
        {
            Debug.Log("EventNull");
        }
        OnMoveEvent?.Invoke(dir);
    }
}
