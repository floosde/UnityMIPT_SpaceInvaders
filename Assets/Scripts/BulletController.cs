using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private Transform _bullet;

    public GameObject powerUp;

    public float speed;

    public float maxBound;
    void Start()
    {
        _bullet = GetComponent<Transform>();
    }

    private void FixedUpdate()
    {
        _bullet.position += Vector3.up * speed;
        if (_bullet.position.y >= maxBound)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Enemy"))
        {
            if (col.transform.gameObject.name == "PowerUpEnemy")
            {
                Instantiate(powerUp, col.transform.position, col.transform.rotation);
            }
            Destroy(col.gameObject);
            Destroy(gameObject);
            PlayerScore.playerScore += 10;
        } else if (col.CompareTag("Base"))
        {
            Destroy(gameObject);
        }
    }
}
