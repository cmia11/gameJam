using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameState : MonoBehaviour
{
    public int score = 0;
    public float timeLeft;
    private float timeTotal;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI startText;
    public bool isGameOver = false;
    public Button buttonRestart;
    public TextMeshProUGUI title;
    private AudioSource playerAudio;
    public AudioClip fireSound;
    private int timeFire1;
    private int timeFire2;
    private int timeFire3;



    // Start is called before the first frame update
    void Start()
    {
        StartGame();
        timeTotal = 100;
        timeLeft = timeTotal;
        playerAudio = GetComponent<AudioSource>();
        //timeFire1 = Random.Range(30, 50);
        timeFire1 = Random.Range(30,50);
        timeFire2 = Random.Range(50, 75);
        timeFire3 = Random.Range(75, 100);

    }

    // Update is called once per frame
    void Update()
    {

        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0)
        {
            Debug.Log("GAME OVER!");
            Debug.Log("Score: " + score);
            
            gameOverText.gameObject.SetActive(true);
            buttonRestart.gameObject.SetActive(true);
            isGameOver = true;
        }

        if (Mathf.Round(timeTotal - timeLeft) == timeFire1)
        {
            playerAudio.PlayOneShot(fireSound,1.0f);
            
        }
        if (Mathf.Round(timeTotal - timeLeft) == timeFire2)
        {
            playerAudio.PlayOneShot(fireSound, 1.0f);

        }
        if (Mathf.Round(timeTotal - timeLeft) == timeFire3)
        {
            playerAudio.PlayOneShot(fireSound, 1.0f);

        }
        scoreText.text = "Score: " + score;
    }

    public void StartGame()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        gameOverText.gameObject.SetActive(false);
        


    }
}
