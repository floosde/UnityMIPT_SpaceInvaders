using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Transform _player;

    public static Vector3 playerStartPos;

    public static int lifesCount;

    public float speed;

    public float maxBound, minBound;
    
    public GameObject shot;

    public Transform shotSpawn;

    public float fireRate;

    private float _nextFire;
    
    void Start()
    {
        lifesCount = 3;
        _player = GetComponent<Transform>();
        playerStartPos = _player.position;
    }
    
    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");

        if ((_player.position.x < minBound && h < 0) ||
            (_player.position.x > maxBound && h > 0)) 
        {
            h = 0;
        }

        _player.position += speed * h * Vector3.right;
    }

    private void Update()
    {
        if ((Input.GetButton("Fire1") || Input.GetButton("Jump")) && Time.time > _nextFire)
        {
            _nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("PowerUp"))
        {
            Destroy(col.gameObject);
            speed += 0.5f;
            fireRate -= 0.2f;
            StartCoroutine(PowerUpTimer());
        }
    }

    IEnumerator PowerUpTimer()
    {
        yield return new WaitForSeconds(7);
        speed -= 0.5f;
        fireRate += 0.2f;
    }
}

