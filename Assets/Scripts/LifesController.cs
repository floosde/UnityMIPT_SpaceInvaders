using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifesController : MonoBehaviour
{
    public static int prevLifesCount; 
    void Start()
    {
        prevLifesCount = 3;
    }
    void Update()
    {
        if (prevLifesCount > PlayerController.lifesCount)
        {
            Destroy(gameObject.transform.GetChild(PlayerController.lifesCount).gameObject);
        }
        prevLifesCount = PlayerController.lifesCount;
    }
}
