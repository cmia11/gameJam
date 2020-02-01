using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideCursorObject : MonoBehaviour
{
    GameObject activeObject = null;
    string tagPlayer;
    private bool keyPressedOnce = false;
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        

        if (Input.GetKeyDown(KeyCode.Space))
        {
            keyPressedOnce = !keyPressedOnce;
            
            
        }

        if (keyPressedOnce && activeObject !=null)
        {
            Debug.Log("2fois");
            activeObject.transform.position = transform.position;
        }


    }

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("collision détectée");
        activeObject = other.gameObject;
    }

    public void OnTriggerExit(Collider other)
    {
        activeObject = null;
    }
}