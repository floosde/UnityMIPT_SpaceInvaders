using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class EnemyBulletController : MonoBehaviour
{
    private Transform _bullet;

    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        _bullet = GetComponent<Transform>();
    }

    private void FixedUpdate()
    {
        _bullet.position += Vector3.up * -speed;
        if (_bullet.position.y <= -10)
        {
            Destroy(_bullet.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            Destroy(gameObject);
            --PlayerController.lifesCount;
            col.gameObject.GetComponent<Transform>().position = PlayerController.playerStartPos;
            if (PlayerController.lifesCount == 0)
            {
                GameOver.isPlayerDead = true;
            }
        } else if (col.CompareTag("Base"))
        {
            GameObject playerBase = col.gameObject;
            BaseHealth baseHealth = playerBase.GetComponent<BaseHealth>();
            baseHealth.health -= 1;
            Destroy(gameObject);
        }
    }
}

