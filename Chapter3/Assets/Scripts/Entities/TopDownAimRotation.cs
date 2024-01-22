using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TopDownAimRotation : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    private TopDownCharacterController _controller;

    private void Awake()
    {
        _controller = GetComponent<TopDownCharacterController>();
    }
    private void Start()
    {
        _controller.OnLookEvent += OnAim;
    }
    private void  OnAim(Vector2 mouseDirection)
    {
        Rotate(mouseDirection);
    }
    private void Rotate (Vector2 direction)
    {
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg ; // ������ͷ��� ����  = �÷��̾�� ���콺 ���� ���� 
        Debug.Log(rotZ);
        spriteRenderer.flipX = Mathf.Abs(rotZ) > 90f;
    }
}
