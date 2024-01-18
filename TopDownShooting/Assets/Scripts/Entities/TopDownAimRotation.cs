using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownAimRotation : MonoBehaviour
{
    [SerializeField] private SpriteRenderer armRenderer;
    [SerializeField] private Transform armPivot;

    [SerializeField] private SpriteRenderer charcterRenderer;

    private TopDownPlayerController _controller;

    private void Awake()
    {
        _controller = GetComponent<TopDownPlayerController>();
    }

    private void Start()
    {
        _controller.OnLookEvent += OnAim;
    }

    public void OnAim(Vector2 newAimRotation)
    {
        RotateArm(newAimRotation);
    }
    public void RotateArm(Vector2 dir)
    {
        float rotZ = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        armRenderer.flipY = Mathf.Abs(rotZ) > 90f;
        charcterRenderer.flipX = armRenderer.flipY;
        armPivot.rotation = Quaternion.Euler(0,0,rotZ);
    }
}
