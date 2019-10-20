using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : Unit
{
    [SerializeField] private int _lives = 5;
    [SerializeField] private float _speed = 3.0f;
    [SerializeField] private float _jumpForce = 15.0f;

    private bool _isGrounded = false;
    private Bullet bullet;

    private CharState State
    {
        get { return (CharState)_animator.GetInteger("State"); }
        set { _animator.SetInteger("State", (int)value); }
    }

    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private SpriteRenderer _sprite;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _sprite = GetComponentInChildren<SpriteRenderer>();

        bullet = Resources.Load<Bullet>("Bullet");
    }

    private void FixedUpdate()
    {
        CheckGround();
    }

    private void Update()
    {
        if (_isGrounded) State = CharState.Idle;
        if (Input.GetButton("Fire1")) Shoot();
        if (Input.GetButton("Horizontal")) Run();
        if (_isGrounded && Input.GetButton("Jump")) Jump();
    }

    private void Run()
    {
        Vector3 dir = transform.right * Input.GetAxis("Horizontal");
        transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, _speed * Time.deltaTime);
        _sprite.flipX = dir.x < 0.0f;

        if (_isGrounded) State = CharState.Run;
    }

    private void Jump()
    {
        State = CharState.Jump;
        _rigidbody.AddForce(transform.up * _jumpForce, ForceMode2D.Impulse);

    }

    private void Shoot()
    {
        Vector3 position = transform.position; position.y += 1.0f;
        Instantiate(bullet, position, bullet.transform.rotation);

    }

    private void CheckGround()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.3f);
        _isGrounded = colliders.Length > 1;
        if (!_isGrounded) State = CharState.Run;
    }


}

public enum CharState
{
    Idle,
    Run,
    Jump
}