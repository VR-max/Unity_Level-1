using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _hp;
    [SerializeField] private float _speed;
    [SerializeField] private float _distance;

    private sbyte _dir;
    private float _leftBorder;
    private float _rightBorder;
    private bool _dead;
    private Rigidbody2D _rb;
    private SpriteRenderer _sr;

    void Start()
    {
        _dead = false;
        _dir = 1;
        _leftBorder = transform.position.x - _distance;
        _rightBorder = transform.position.x + _distance;
        _rb = GetComponent<Rigidbody2D>();
        _sr = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        if (!_dead)
        {
            if (_dir == 1 && transform.position.x > _rightBorder)
            {
                _sr.flipX = false;
                _dir = -1;
            }
            if (_dir == -1 && transform.position.x < _leftBorder)
            {
                _sr.flipX = true;
                _dir = 1;
            }
            Move();
        }
    }

    private void Move()
    {
        _rb.velocity = new Vector2(_speed * _dir, _rb.velocity.y);
    }
    public void TakeDamage()
    {
        _dead = true;
        Destroy(gameObject, 2);
    }
}
