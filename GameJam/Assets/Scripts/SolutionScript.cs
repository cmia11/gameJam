﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolutionScript : MonoBehaviour
{
    public GameObject[] solutions;
    private Vector3 solutionDistance;
    private Quaternion solutionRotation;
    private int currentPuzzleIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (currentPuzzleIndex > 0)
        {
            return;
        }
        GameObject currentSolution = solutions[currentPuzzleIndex];
        solutionDistance = currentSolution.transform.GetChild(0).position - currentSolution.transform.GetChild(1).position;
        solutionRotation = Quaternion.Inverse(currentSolution.transform.GetChild(1).rotation) * currentSolution.transform.GetChild(0).rotation;

        GameObject repairedObject = GameObject.FindGameObjectWithTag("repairedObject");
        GameObject repairPart = GameObject.FindGameObjectWithTag("repairPart");

        if (repairedObject == null || repairPart == null)
        {
            return;
        }

        float distance = (repairedObject.transform.position - repairPart.transform.position - solutionDistance).sqrMagnitude;
        float rotationDistance = Quaternion.Angle(solutionRotation, Quaternion.Inverse(repairPart.transform.rotation) * repairedObject.transform.rotation);

        if (distance < 0.15 && rotationDistance < 16)
        {
            Debug.Log("Success");
            repairPart.transform.SetPositionAndRotation(repairedObject.transform.position + solutionDistance, repairedObject.transform.rotation * solutionRotation);
            repairPart.transform.SetParent(repairedObject.transform);

            GameObject.Find("GameState").GetComponent<GameState>().score++;
            currentPuzzleIndex++;
        } else
        {
            Debug.Log(distance + " ----- " + rotationDistance);
        }
    }
}
