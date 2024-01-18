using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownMovement : MonoBehaviour
{
    private TopDownPlayerController _controller;
    private CharacterStatHandler _stats;

    private Vector2 _movementDirection = Vector2.zero;
    private Rigidbody2D _rigidBody;

    private void Awake()
    {
        _controller = GetComponent<TopDownPlayerController>();
        _stats = GetComponent<CharacterStatHandler>();
        _rigidBody = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        _controller.OnMoveEvent += Move;
    }
    private void FixedUpdate()
    {
        ApplyMovement(_movementDirection);
    }
    
    private void ApplyMovement(Vector2 dir)
    {
        dir = dir * _stats.CurrentStates.speed;
        _rigidBody.velocity = dir;
    }
    private void Move(Vector2 dir)
    {
        _movementDirection = dir;
    }
    private void Text(Vector2 dir)
    {
        Debug.Log("¹ö±×");
    }
}
