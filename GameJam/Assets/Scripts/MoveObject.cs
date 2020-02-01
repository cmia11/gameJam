using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    // Start is called before the first frame update

    private float inputX;
    private float inputY;
    private float inputZ;
    private float speed = 4;
    private float speedR = 6;
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
        Move3DTranslate();
    }

    void Move3DTranslate()
    {
        inputX = Input.GetAxis("AxeY");
        transform.Translate(new Vector3(0,1,0) * Time.deltaTime * inputX * speed, Space.World);

        if (transform.position.x > xMax)
        {
            transform.position = new Vector3(8, transform.position.y, transform.position.z);
        }

        if (transform.position.x < xMin)
        {
            transform.position = new Vector3(-6, transform.position.y, transform.position.z);
        }

        // gérer le bug quand ça sort de l'écran

        inputY = Input.GetAxis("AxeX");
        transform.Translate(new Vector3(1,0,0) * Time.deltaTime * inputY * speed, Space.World);

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

        inputZ = Input.GetAxis("AxeZ");
        transform.Translate(new Vector3(0,0,1) * Time.deltaTime * inputZ * speed, Space.World);

        if (transform.position.z > zMax)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 8);
        }

        if (transform.position.z < zMin)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -5);
        }

        float inputRotationX = Input.GetAxis("RotationX");
        transform.Rotate(new Vector3(1, 0, 0) * Time.deltaTime * inputRotationX * speedR, Space.World);
        transform.Rotate(new Vector3(1, 0, 0) * Time.deltaTime * inputRotationX * speedR, Space.World);

        float inputRotationY = Input.GetAxis("RotationY");
        transform.Rotate(new Vector3(0, 1, 0) * Time.deltaTime * inputRotationY * speedR, Space.World);

        float inputRotationZ = Input.GetAxis("RotationZ");
        transform.Rotate(new Vector3(0, 0, 1) * Time.deltaTime * inputRotationZ * speedR, Space.World);
    }

 
           
        

    }

