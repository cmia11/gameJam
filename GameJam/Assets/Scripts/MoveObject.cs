using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    // Start is called before the first frame update

    private float inputX;
    private float inputY;
    private float inputZ;
    public float speed = 0.2f;
    public float speedR = 40;
    private float xMin = -0.4f;
    private float xMax = 0.4f;
    private float yMin = 0 ;
    private float yMax = 0.35f;
    private float zMin = -0.25f;
    private float zMax = 0.4f;

    private bool rotationMode = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.JoystickButton1))
        {
            rotationMode = !rotationMode;
        }

        Move3DTranslate();
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.JoystickButton2))
        {
            if (speed < 1.5 && speedR < 200)
            {
                speed += 0.02f;
                speedR += 5;
                Debug.Log("j'ai pressé haut");
            }

        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.JoystickButton3))
        {
            if(speed > 0.05 && speedR > 20)
            {
                speed -= 0.02f;
                speedR -= 5;
                Debug.Log("j'ai pressé la touche du bas");
            }

        }
    }

    void Move3DTranslate()
    {
        inputX = Input.GetAxis("AxeY") * (rotationMode ? 0 : 1);
        transform.Translate(new Vector3(0,1,0) * Time.deltaTime * inputX * speed, Space.World);

        if (transform.position.x > xMax)
        {
            transform.position = new Vector3(xMax, transform.position.y, transform.position.z);
        }

        if (transform.position.x < xMin)
        {
            transform.position = new Vector3(xMin, transform.position.y, transform.position.z);
        }

        // gérer le bug quand ça sort de l'écran

        inputY = Input.GetAxis("AxeX") * (rotationMode ? 0 : 1);
        transform.Translate(new Vector3(1,0,0) * Time.deltaTime * inputY * speed, Space.World);

        //gérer le bug lorsque ça sort de l'écran
        if (transform.position.y > yMax)
        {
            transform.position = new Vector3(transform.position.x, yMax, transform.position.z);
        }

        // gérer le bug lorsque ça sort de l'écran
        if (transform.position.y < yMin)
        {
            transform.position = new Vector3(transform.position.x, yMin, transform.position.z);
        }

        inputZ = Input.GetAxis("AxeZ") * (rotationMode ? 0 : 1);
        transform.Translate(new Vector3(0,0,1) * Time.deltaTime * inputZ * speed, Space.World);

        if (transform.position.z > zMax)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zMax);
        }

        if (transform.position.z < zMin)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zMin);
        }

        float inputRotationX = rotationMode ? Input.GetAxis("AxeY") : Input.GetAxis("RotationX");
        transform.Rotate(new Vector3(1, 0, 0) * Time.deltaTime * inputRotationX * speedR, Space.World);
        transform.Rotate(new Vector3(1, 0, 0) * Time.deltaTime * inputRotationX * speedR, Space.World);

        float inputRotationY = rotationMode ? Input.GetAxis("AxeX") : Input.GetAxis("RotationY");
        transform.Rotate(new Vector3(0, 1, 0) * Time.deltaTime * inputRotationY * speedR, Space.World);

        float inputRotationZ = rotationMode ? Input.GetAxis("AxeZ") : Input.GetAxis("RotationZ");
        transform.Rotate(new Vector3(0, 0, 1) * Time.deltaTime * inputRotationZ * speedR, Space.World);
    }

 
           
        

    }

