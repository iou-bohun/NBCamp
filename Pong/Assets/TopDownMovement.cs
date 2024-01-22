using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownMovement : MonoBehaviour
{
    private TopDownCharacterController _controller;

    private Vector2 _movementDir = Vector2.zero;
    private Rigidbody2D rigid;

    private void Awake()
    {
        _controller = GetComponent<TopDownCharacterController>();
        rigid = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        _controller.OnMoveEvent += Move;
    }
    private void Move(Vector2 direction)
    {
        _movementDir = direction;
        Debug.Log("move");
    }
}
