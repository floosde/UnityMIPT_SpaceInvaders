using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class BaseHealth : MonoBehaviour
{
    public float health = 3;
    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
