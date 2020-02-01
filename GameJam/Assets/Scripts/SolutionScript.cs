using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolutionScript : MonoBehaviour
{
    public GameObject[] solutions;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        GameObject repairedObject = GameObject.FindGameObjectWithTag("repairedObject");
        GameObject repairPart = GameObject.FindGameObjectWithTag("repairPart");

        if (repairedObject == null || repairPart == null)
        {
            return;
        }

        float distance = (repairedObject.transform.position - repairPart.transform.position).sqrMagnitude;
        float rotationDistance = (repairedObject.transform.rotation.eulerAngles - repairPart.transform.rotation.eulerAngles).sqrMagnitude;

        if (distance < 0.15 && rotationDistance < 0.01)
        {
            print("Success");
            repairedObject.SetActive(false);
            repairPart.SetActive(false);
            solutions[0].transform.SetPositionAndRotation(repairedObject.transform.position, repairedObject.transform.rotation);
            solutions[0].SetActive(true);
        } else
        {
            print(distance + " ----- " + rotationDistance);
        }
    }
}
