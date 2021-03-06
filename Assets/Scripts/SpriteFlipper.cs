﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]

public class SpriteFlipper : MonoBehaviour
{
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private float _moveDirection;
    private bool _isFacingLeft = false;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        _moveDirection = Input.GetAxisRaw("Horizontal");
        _animator.SetFloat("Speed", Mathf.Abs(_moveDirection));
        FlipLook();
    }

    private void FlipLook()
    {
        if (_moveDirection > 0 && _isFacingLeft)
        {
            Flip();
        }
        else if (_moveDirection < 0 && !_isFacingLeft)
        {
            Flip();
        }
    }

    private void Flip()
    {
        _isFacingLeft = !_isFacingLeft;
        _spriteRenderer.flipX = _isFacingLeft;
    }
}
