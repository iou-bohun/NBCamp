using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownAnimationController : TopDownAnimations
{
    private static readonly int IsWalking = Animator.StringToHash("IsWalking");
    private static readonly int Attack = Animator.StringToHash("Attack");
    private static readonly int IsHit = Animator.StringToHash("IsHit");
    //string�� �񱳴� ����� ���� Hash������ ���ϵ��� ó�����Ѵ�.
    //���� �̸��� ���̻� ��� �Ұ���
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
