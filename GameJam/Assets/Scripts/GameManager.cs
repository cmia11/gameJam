using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    
    public GameObject titleS;
    public GameObject tutoClavier;
    public float timeStart;
    // Start is called before the first frame update
    void Start()
    {
        timeStart = 30;
    }

    // Update is called once per frame
    void Update()
    {
        timeStart -= Time.deltaTime;
        if (Mathf.Round(timeStart) == 20)
        {
            tutoClavier.SetActive(true);
            titleS.SetActive(false);
        }

        if (timeStart <= 0)
        {
            SceneManager.LoadScene(1);
        }
        
    }
}
