using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class GameState : MonoBehaviour
{
    public int score;
    public float timeLeft;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    // Start is called before the first frame update
    void Start()
    {
        timeLeft = 60;
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0)
        {
            Debug.Log("GAME OVER!");
            Debug.Log("Score: " + score);
        }
    }
}
