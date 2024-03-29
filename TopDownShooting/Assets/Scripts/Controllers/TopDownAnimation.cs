using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownAnimation : MonoBehaviour
{
    protected Animator animator;
    protected TopDownPlayerController controller;

    protected virtual void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        controller = GetComponent<TopDownPlayerController>();
    }
}