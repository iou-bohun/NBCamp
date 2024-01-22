using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownMovement : MonoBehaviour
{
    private TopDownCharacterController _controller;
    private Rigidbody2D _rigidbody;
    Vector2 newDirection = Vector2.zero;    

    private void Awake()
    {
        _controller = GetComponent<TopDownCharacterController>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        _controller.OnMoveEvent += Move;
    }

    private void FixedUpdate()
    {
        ApplyMovement(newDirection);
    }

    private void Move(Vector2 dir)
    {
        newDirection = dir; 
    }
    private void ApplyMovement(Vector2 dir)
    {
        dir = dir * 5;
        _rigidbody.velocity = dir;
    }
}
