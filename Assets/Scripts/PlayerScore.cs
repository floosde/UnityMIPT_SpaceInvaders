using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{
    public static float playerScore = 0;

    private Text _scoreText;
    void Start()
    {
        _scoreText = GetComponent<Text>();
    }
    
    void Update()
    {
        _scoreText.text = "Score: " + playerScore;
    }
}
