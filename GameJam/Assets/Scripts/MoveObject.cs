using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    // Start is called before the first frame update

    private float inputX;
    private float inputY;
    private float inputZ;
    private float speed = 5;
    private float xMin = -6;
    private float xMax = 8;
    private float yMin = 0 ;
    private float yMax = 7;
    private float zMin = -5;
    private float zMax = 8;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        inputX = Input.GetAxis("Vertical");
        transform.Translate(Vector3.up * Time.deltaTime * inputX * speed);
        if (transform.position.x > xMax)
        {
            transform.position = new Vector3(8, transform.position.y, transform.position.z);
        }

        if (transform.position.x < xMin)
        {
            transform.position = new Vector3(-6, transform.position.y, transform.position.z);
        }

        // gérer le bug quand ça sort de l'écran

        inputY = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * Time.deltaTime * inputY * speed);
        
        //gérer le bug lorsque ça sort de l'écran
        if (transform.position.y > yMax)
        {
            transform.position = new Vector3(transform.position.x, 7, transform.position.z);
        }
        
        // gérer le bug lorsque ça sort de l'écran
        if (transform.position.y < yMin)
        {
            transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        }

        inputZ = Input.GetAxis("Mouse ScrollWheel");
        transform.Translate(Vector3.forward * Time.deltaTime * inputZ * speed);

        if (transform.position.z > zMax)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 8);
        }

        if (transform.position.z < zMin)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -5);
        }
    }
}
