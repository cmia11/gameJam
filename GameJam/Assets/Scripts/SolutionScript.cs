using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolutionScript : MonoBehaviour
{
    public GameObject[] solutions;
    private Vector3 solutionDistance;
    private Vector3 solutionRotation;
    // Start is called before the first frame update
    void Start()
    {
        GameObject currentSolution = solutions[0];
        solutionDistance = currentSolution.transform.GetChild(0).position - currentSolution.transform.GetChild(1).position;
        solutionRotation = currentSolution.transform.GetChild(0).eulerAngles - currentSolution.transform.GetChild(1).eulerAngles;
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

        float distance = (repairedObject.transform.position - repairPart.transform.position - solutionDistance).sqrMagnitude;
        float rotationDistance = (repairedObject.transform.eulerAngles - repairPart.transform.eulerAngles - solutionRotation).sqrMagnitude;

        if (distance < 0.15 && rotationDistance < 0.1)
        {
            Debug.Log("Success");
            repairPart.transform.SetPositionAndRotation(repairedObject.transform.position + solutionDistance, repairedObject.transform.rotation * Quaternion.Euler(solutionRotation));
            repairPart.transform.SetParent(repairedObject.transform);
        } else
        {
            Debug.Log(distance + " ----- " + rotationDistance);
        }
    }
}
