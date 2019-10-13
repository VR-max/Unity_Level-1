using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private int _dir;
    private int _speed = 10;
    private int _damage = 5;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 5);
    }

    public void Init(int dir)
    {
        _dir = dir;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(new Vector2(Time.deltaTime * _speed * _dir, 0));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            collision.GetComponent<Enemy>().TakeDamage(_damage);
        }
        Destroy(gameObject);
    }
}
