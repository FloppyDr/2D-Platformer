using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Jump : MonoBehaviour
{
    [SerializeField] private float _jumpForce;
    [SerializeField] private Transform _groundChek;
    [SerializeField] private LayerMask _groundLayer;

    private Rigidbody2D _rigidbody2D;
    private float _groundCheckRadius = 0.1f;
    private bool _isGrounded;
    private bool _isJump;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            _isJump = true;
        }
    }

    private void FixedUpdate()
    {
        _isGrounded = false;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(_groundChek.position, _groundCheckRadius, _groundLayer);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                _isGrounded = true;
            }
        }

        DoJump();
    }

    private void DoJump()
    {
        if (_isGrounded && _isJump)
        {
            _isGrounded = false;
            _isJump = false;
            _rigidbody2D.AddForce(new Vector2(0f, _jumpForce));
        }
    }
}
