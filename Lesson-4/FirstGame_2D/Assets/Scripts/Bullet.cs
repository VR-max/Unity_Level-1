using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private int _dir;
    private int _speed = 1;
    private int _damage = 5;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 5);
    }

    public void Init(int dir)
    {
        _dir = dir;
        GetComponent<Rigidbody2D>().AddForce(Vector3.right * 50 * _dir, ForceMode2D.Impulse);
        GetComponent<Rigidbody2D>().AddTorque(50);
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(new Vector2(Time.deltaTime * _speed * _dir, 0));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Hero")
        {
            return;
        }

        if (collision.tag == "Enemy")
        {
            collision.GetComponent<Enemy>().TakeDamage(_damage);
        }
        Destroy(gameObject);
    }
}
