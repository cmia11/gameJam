using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Restart : MonoBehaviour
{
    private Button buttonRestart;
    // Start is called before the first frame update
    void Start()
    {
        buttonRestart = GameObject.Find("Button").GetComponent<Button>();
        buttonRestart.onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    void Update()
    {

    }



    void TaskOnClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
