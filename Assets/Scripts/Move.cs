using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class Move : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Rigidbody2D _rigidbody2D;
    private float _horizontalMove;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _horizontalMove = Input.GetAxisRaw("Horizontal") * _speed;
    }

    private void FixedUpdate()
    {
        Movement(_horizontalMove);
    }

    private void Movement(float horizontalMove)
    {
        Vector3 targetVelocity = new Vector2(horizontalMove, _rigidbody2D.velocity.y);
        _rigidbody2D.velocity = targetVelocity;
    }
}
