using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownEnemyConrtoller : TopDownPlayerController
{
    GameManager gameManager;
   protected Transform closestTarget { get; private set; }

    protected override void Awake()
    {
        base.Awake();
    }
    protected virtual void Start()
    {
        gameManager = GameManager.Instance;
        closestTarget = gameManager.Player;
    }
    protected virtual  void FixedUpdate()
    {
        
    }

    protected float DistanceToTarget()
    {
        return Vector3.Distance(transform.position , closestTarget.position);
    }
    protected Vector2 DiretcionToTarget()
    {
        return (closestTarget.position - transform.position).normalized;  
    }
}
