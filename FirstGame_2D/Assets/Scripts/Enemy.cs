using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _hp;
    

    public void TakeDamage(int damage)
    {
        Debug.Log("Auch " + damage);
        Destroy(gameObject);
    }
}
