using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownPlayerController : MonoBehaviour
{
    public event Action<Vector2> OnMoveEvent;
    public event Action<Vector2> OnLookEvent;
    public event Action OnAttackEvent;
    protected CharacterStatHandler Stats { get; private set; }

    private float _timeSinceLastAttack = float.MaxValue;
    protected bool isAttacking { get; set; }

    protected virtual  void Awake()
    {
        Stats = GetComponent<CharacterStatHandler>();
    }
    protected virtual void Update()
    {
        HandleAttackDelay();
    }
    private void HandleAttackDelay()
    {
        if(Stats.CurrentStates.attackSo == null)
        {
            return;
        }
        if (_timeSinceLastAttack <= Stats.CurrentStates.attackSo.delay)
        {
            _timeSinceLastAttack += Time.deltaTime;
        }
        else if(isAttacking && _timeSinceLastAttack> Stats.CurrentStates.attackSo.delay)
        {
            _timeSinceLastAttack = 0;
            CallAttackEvent();
        }
    }
    public void CallMoveEvent(Vector2 direction)
    {
        OnMoveEvent?.Invoke(direction);
    }
    public void CallLookEvent(Vector2 direction)
    {
        OnLookEvent?.Invoke(direction);
    }

    public void CallAttackEvent()
    {
        OnAttackEvent?.Invoke();
    }
    
}
