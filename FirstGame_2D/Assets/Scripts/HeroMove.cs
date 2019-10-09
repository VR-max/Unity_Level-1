using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroMove : MonoBehaviour
{

    public float timeDelta;
    public int speed = 5;
    [SerializeField] private GameObject _bullet;
    [SerializeField] private Transform _bulletPosition;
    [SerializeField] private SpriteRenderer _flip;
    [SerializeField] private Transform _TransformPistole;

    private int _dir = 1;

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(new Vector2(Time.deltaTime * speed, 0));
            _flip.flipX = false;
            _TransformPistole.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
            

        else if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(new Vector2(Time.deltaTime * speed * (-1), 0));
            _flip.flipX = true;
            _TransformPistole.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
            

        if (Input.GetKeyDown(KeyCode.E))
            Fire();
    }

    private void Fire()
    {
        var bullet = Instantiate(_bullet, _bulletPosition.position, Quaternion.identity);
        bullet.GetComponent<Bullet>().Init(_dir);
    }

}
