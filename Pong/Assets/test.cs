using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : TopDownCharacterController
{
    private TopDownCharacterController _controller;
    private void Awake()
    {
        _controller = GetComponent<TopDownCharacterController>();
    }
    private void Start()
    {
        _controller.OnMoveEvent += Test;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("1");
            Vector2 dir = Vector2.zero;
            CallEvent(dir);
        }
    }
    private void Test(Vector2 dir)
    {
        Debug.Log("TTEST");
    }
}
