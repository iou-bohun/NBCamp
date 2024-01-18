using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownShooting : MonoBehaviour
{
    private TopDownPlayerController _controller;

    [SerializeField]private Transform profectionSpqwnPosition;
    private Vector2 _aimDirecton = Vector2.right;

    public GameObject prefabs;
    private void Awake()
    {
        _controller = GetComponent<TopDownPlayerController>();
    }
    private void Start()
    {
        _controller.OnAttackEvent += OnShot;
        _controller.OnLookEvent += OnAim;
    }

    private void OnAim(Vector2 newAimDir)
    {
        _aimDirecton = newAimDir;
    }
    private void OnShot()
    {
        CreateProjectile();
    }
    private void CreateProjectile()
    {
        Instantiate(prefabs, profectionSpqwnPosition.position, Quaternion.identity);
    }
}
