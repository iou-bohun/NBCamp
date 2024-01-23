using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownAnimationController : TopDownAnimations
{
    private static readonly int IsWalking = Animator.StringToHash("IsWalking");
    private static readonly int Attack = Animator.StringToHash("Attack");
    private static readonly int IsHit = Animator.StringToHash("IsHit");
    //string의 비교는 비용이 높아 Hash값으로 비교하도록 처리하한다.
    //같은 이름은 더이상 사용 불가능
    protected override void Awake()
    {
        base.Awake();
    }
    private void Start()
    {
        controller.OnMoveEvent += Move;
    }
    private void Move(Vector2 directionVector)
    {
        animator.SetBool(IsWalking, directionVector.magnitude > 0.5);
    }
}
