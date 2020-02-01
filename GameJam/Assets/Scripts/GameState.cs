using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using 

public class GameState : MonoBehaviour
{
    public int score;
    public float timeLeft;
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
