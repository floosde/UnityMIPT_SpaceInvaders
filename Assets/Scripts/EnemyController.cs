using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    private Transform _enemyHolder;

    public float speed;

    public GameObject shot;

    public Text winText;

    public float fireRate;
    
    public int hardModeEnemyCount;
    void Start()
    {
        winText.enabled = false;
        InvokeRepeating("MoveEnemy", 0.1f, 0.3f);
        _enemyHolder = GetComponent<Transform>();
    }
    void MoveEnemy()
    {
        _enemyHolder.position += Vector3.right * speed;

        foreach (Transform enemy in _enemyHolder)
        {

            if (enemy.position.x < -14 || enemy.position.x > 14)
            {
                speed = -speed;
                if (_enemyHolder.position.y > -3.5)
                {
                    _enemyHolder.position += Vector3.down * 0.5f;
                }

                return;
            }
            
            if (_enemyHolder.childCount <= hardModeEnemyCount)
            {
                fireRate = 0.90f;
            }

            if (Random.value > fireRate)
            {
                Instantiate(shot, enemy.position, enemy.rotation);
            }
            
            if (enemy.position.y <= -4)
            {
                GameOver.isPlayerDead = true;
                Time.timeScale = 0;
            }
        }

        if (_enemyHolder.childCount <= hardModeEnemyCount)
        {
            CancelInvoke();
            InvokeRepeating("MoveEnemy", 0.1f, 0.25f);
        }

        if (_enemyHolder.childCount == 0)
        {
            winText.enabled = true;
        }
    }
}
