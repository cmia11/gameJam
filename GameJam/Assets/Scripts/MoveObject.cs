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

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        inputX = Input.GetAxis("Vertical");
        transform.Translate(Vector3.up * Time.deltaTime * inputX * speed);

        // gérer le bug quand ça sort de l'écran

        inputY = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * Time.deltaTime * inputY * speed);
        
        //gérer le bug lorsque ça sort de l'écran
        //if (transform.position.y < 7)
        //{
        //    transform.position = new Vector3(transform.position.x, 7, transform.position.z);
        //}
        
        // gérer le bug lorsque ça sort de l'écran
        //if (transform.position.y > 0)
        //{
        //    transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        //}

        inputZ = Input.GetAxis("Mouse ScrollWheel");
        transform.Translate(Vector3.forward * Time.deltaTime * inputZ * speed);

        
    }
}
