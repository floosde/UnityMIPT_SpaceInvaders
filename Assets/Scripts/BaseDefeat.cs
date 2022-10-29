using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseDefeat : MonoBehaviour
{
    private Transform _playerBase;
    void Start()
    {
        _playerBase = GetComponent<Transform>();
    }
    void Update()
    {
        if (_playerBase.childCount == 0)
        {
            GameOver.isPlayerDead = true;
        }
    }
}
