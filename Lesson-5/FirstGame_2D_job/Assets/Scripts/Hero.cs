using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpHeight;
    [SerializeField] private GameObject _bullet;

    public int _hp;
    private sbyte _dir;
    private bool _onFloor;
    private bool _dead;
    private Rigidbody2D _rb;
    private SpriteRenderer _sr;
    private SpriteRenderer _srGun;
    private GameObject _gun;
    private Camera _mc;

    // Start is called before the first frame update
    void Start()
    {
        _dead = false;
        _mc = Camera.main;
        _rb = GetComponent<Rigidbody2D>();
        _sr = GetComponent<SpriteRenderer>();
        _srGun = GameObject.Find("Gun").GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        _mc.transform.position = new Vector3(transform.position.x, transform.position.y, _mc.transform.position.z);
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.D))
        {
            _sr.flipX = false;
            _srGun.flipX = false;
            _dir = 1;
            Move();
        }
        else if (Input.GetKey(KeyCode.A))
        {
            _sr.flipX = true;
            _srGun.flipX = true;
            _dir = -1;
            Move();
        }
        else
        {
            Stop();
        }

        if (Input.GetKey(KeyCode.W) && _onFloor)
        {
            _onFloor = false;
            Jump();
        }
        
        if (_rb.velocity.y == 0)
        {
            _onFloor = true;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            var bullet = Instantiate(_bullet, transform.position, new Quaternion());
            bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(_dir * 7, 3);
        }


    }

    void Awake()
    {
        _hp = 100;

    }

    private void Move()
    {
        _rb.velocity = new Vector2(_speed * _dir, _rb.velocity.y);
    }

    private void Stop()
    {
        _rb.velocity = new Vector2(0, _rb.velocity.y);
    }

    private void Jump()
    {
        _rb.velocity = new Vector2(_rb.velocity.x, _jumpHeight);
    }
}
