using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroMove : MonoBehaviour
{

    public int _hp;
    public float timeDelta;
    public int speed = 5;

    [SerializeField] private GameObject _bullet;
    [SerializeField] private Transform _bulletPosition;
    [SerializeField] private float force = 200;


    private int _dir = 1;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.D))
        {   
            if (_dir != 1)
            {
                spriteRenderer.flipX = true;
                _dir = 1;
            }
            GetComponent<Rigidbody2D>().AddForce(Vector3.right * 10);
        }
            

        if (GetComponent<Rigidbody2D>().velocity.x > speed)
            GetComponent<Rigidbody2D>().velocity = new Vector3(speed, GetComponent<Rigidbody2D>().velocity.y, 0);

        if (Input.GetKey(KeyCode.A))
            transform.Translate(new Vector2(Time.deltaTime * speed * (-1), 0));

        if (Input.GetKey(KeyCode.W))
            rb.AddForce(Vector3.up * force, ForceMode2D.Force);


            if (Input.GetKeyDown(KeyCode.E))
            Fire();
    }

    private void Fire()
    {
        var bullet = Instantiate(_bullet, _bulletPosition.position, Quaternion.identity);
        bullet.GetComponent<Bullet>().Init(_dir);
    }

}
