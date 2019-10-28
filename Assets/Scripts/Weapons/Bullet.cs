using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage;
    public float speed;
    public float lifeTime;

    private Rigidbody2D _rb;
    private float _timer;

    public void StartMove()
    {
        _timer = lifeTime;
    }
    
    private void Update()
    {
        if (_timer > 0)
            _timer -= Time.deltaTime;
        else
            Destroy(gameObject);

        transform.position += transform.up * speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("Bullet collision");
        Destroy(gameObject);
    }
}