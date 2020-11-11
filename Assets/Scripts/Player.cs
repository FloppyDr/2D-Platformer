using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private Transform _groundChek;
    [SerializeField] private LayerMask _groundLayer;

    private Animator _animator;
    private Rigidbody2D _rigidbody2D;
    private SpriteRenderer _spriteRenderer;
    private float _horizontalMove;
    private float _groundCheckRadius = 0.1f;
    private bool _isFacingLeft = false;
    [SerializeField] private bool _isGrounded;
    [SerializeField] private bool _isJump;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }


    private void Update()
    {
        _horizontalMove = Input.GetAxisRaw("Horizontal") * _speed;

        _animator.SetFloat("Speed", Mathf.Abs(_horizontalMove));

        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            _isJump = true;
        }

    }

    private void FixedUpdate()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(_groundChek.position, _groundCheckRadius, _groundLayer);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                _isGrounded = true;
            }
        }

        Move(_horizontalMove, _isJump);
        _isJump = false;
    }

    private void Flip()
    {
        _isFacingLeft = !_isFacingLeft;
        _spriteRenderer.flipX = _isFacingLeft;
    }

    private void Move(float horizontalMove, bool isJump)
    {
        Vector3 targetVelocity = new Vector2(horizontalMove, _rigidbody2D.velocity.y);

        if (horizontalMove > 0 && _isFacingLeft)
        {
            Flip();
        }
        else if (horizontalMove < 0 && !_isFacingLeft)
        {
            Flip();
        }

        _rigidbody2D.velocity = targetVelocity;

        if (_isGrounded && _isJump)
        {
            _isGrounded = false;
            _rigidbody2D.AddForce(new Vector2(0f, _jumpForce));
        }
    }
}
