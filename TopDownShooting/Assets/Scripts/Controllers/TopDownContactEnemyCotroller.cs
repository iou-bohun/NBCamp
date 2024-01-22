using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TopDownContactEnemyCotroller : TopDownEnemyConrtoller
{
    [SerializeField][Range(0, 100f)] private float followRange;
    [SerializeField] private string targetTag = "Player";
    private bool _isCollidingWithTarget;

    [SerializeField] private SpriteRenderer _spriteRenderer;
    protected override void Start()
    {
        base.Start();
    }
    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        Vector2 direction = Vector2.zero;
        if(DistanceToTarget() < followRange)
        {
            direction = DiretcionToTarget();
        }
        CallMoveEvent(direction);
        Rotate(direction);
    }
    private void Rotate(Vector2 direction)
    {
        float rotz = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        _spriteRenderer.flipX = Mathf.Abs(rotz) > 90f;
;    }
}
