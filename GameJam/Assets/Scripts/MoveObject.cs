using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    // Start is called before the first frame update

    private float inputX;
    private float inputY;
    private float inputZ;
    private float speed = 10;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        inputX = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.up * Time.deltaTime * inputX * speed);
    }
}
