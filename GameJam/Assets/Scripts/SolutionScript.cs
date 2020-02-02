using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolutionScript : MonoBehaviour
{
    public GameObject[] solutions;
    private Vector3 solutionDistance;
    private Quaternion solutionRotation;
    private int currentPuzzleIndex = 0;
    private GameObject currentSolution;
    private bool initializingNextPuzzle = true;
    private float initTime = 0;
    private bool finalizingCurrentPuzzle = false;
    private float finalizeTime = 0;

    private GameObject invisibleWalls;

    // Start is called before the first frame update
    void Start()
    {
        invisibleWalls = GameObject.FindGameObjectWithTag("invisible");
    }

    // Update is called once per frame
    void Update()
    {
        if (currentPuzzleIndex > 1)
        {
            return;
        }

        if (initializingNextPuzzle)
        {
            initializeNextPuzzle();
            return;
        }
        if (finalizingCurrentPuzzle)
        {
            finalizeCurrentPuzzle();
            return;
        }

        GameObject repairedObject = GameObject.FindGameObjectWithTag("repairedObject");
        GameObject repairPart = GameObject.FindGameObjectWithTag("repairPart");

        if (repairedObject == null || repairPart == null)
        {
            return;
        }

        float distance = (repairedObject.transform.position - repairPart.transform.position - solutionDistance).sqrMagnitude;
        float rotationDistance = Quaternion.Angle(solutionRotation, Quaternion.Inverse(repairPart.transform.rotation) * repairedObject.transform.rotation);

        if (distance < 0.0001 && rotationDistance < 16)
        {
            Debug.Log("Success");
            repairPart.transform.SetPositionAndRotation(repairedObject.transform.position + solutionDistance, repairedObject.transform.rotation * solutionRotation);
            repairPart.transform.SetParent(repairedObject.transform);

            GameObject.Find("GameState").GetComponent<GameState>().score++;
            currentPuzzleIndex++;
            finalizingCurrentPuzzle = true;
            finalizeTime = 0;
        } else
        {
            Debug.Log(distance + " ----- " + rotationDistance);
        }
    }

    private void initializeNextPuzzle()
    {
        if (currentSolution == null)
        {
            currentSolution = solutions[currentPuzzleIndex];
            GameObject repairedObjectToClone = getChildWithTag(currentSolution, "repairedObject");
            GameObject repairPartToClone = getChildWithTag(currentSolution, "repairPart");
            GameObject ikeaManualToClone = null;
            try
            {
                ikeaManualToClone = getChildWithTag(currentSolution, "ikeaManual");
            } catch (System.Exception e)
            {
                // Ikea manuals are not mandatory
            }

            GameObject repairedObject = Instantiate(repairedObjectToClone, new Vector3(-0.45f, 0.19f, 0.01f), Random.rotation);
            GameObject repairPart = Instantiate(repairPartToClone, new Vector3(-0.52f, 0.2541f, 0.0136f), Random.rotation);
            GameObject ikeaManual = null;
            if (ikeaManualToClone != null)
            {
                ikeaManual = Instantiate(ikeaManualToClone, new Vector3(-0.4f, 0.146f, -0.0031f), new Quaternion(0,0,0,0));
            }

            repairedObject.GetComponent<Rigidbody>().isKinematic = false;
            repairedObject.GetComponent<Rigidbody>().AddForce(20 * (new Vector3(1, 0, 0) - repairedObject.transform.position).normalized);
            repairPart.GetComponent<Rigidbody>().isKinematic = false;
            repairPart.GetComponent<Rigidbody>().AddForce(20 * (new Vector3(1, 0, 0) - repairPart.transform.position).normalized);
            if (ikeaManual != null)
            {
                ikeaManual.GetComponent<Rigidbody>().isKinematic = false;
                ikeaManual.GetComponent<Rigidbody>().AddForce(40 * (new Vector3(1, 0.5f, 0) - ikeaManual.transform.position).normalized);
            }

            invisibleWalls.SetActive(false);

            solutionDistance = currentSolution.transform.GetChild(0).position - currentSolution.transform.GetChild(1).position;
            solutionRotation = Quaternion.Inverse(currentSolution.transform.GetChild(1).rotation) * currentSolution.transform.GetChild(0).rotation;
            initTime = 0;
        } else
        {
            initTime += Time.deltaTime;
            if (initTime > 0.5)
            {
                invisibleWalls.SetActive(true);
            }
            if (initTime > 2)
            {
                GameObject repairedObject = GameObject.FindGameObjectWithTag("repairedObject");
                repairedObject.GetComponent<Rigidbody>().isKinematic = true;
                GameObject repairPart = GameObject.FindGameObjectWithTag("repairPart");
                repairPart.GetComponent<Rigidbody>().isKinematic = true;
                try
                {
                    GameObject ikeaManual = GameObject.FindGameObjectWithTag("ikeaManual");
                    if (ikeaManual != null)
                    {
                        ikeaManual.GetComponent<Rigidbody>().isKinematic = true;
                    }
                } catch (UnityException)
                {
                    // Ikea manual are not mandatory
                }
                initializingNextPuzzle = false;
            }
        }
    }
    private void finalizeCurrentPuzzle()
    {
        finalizeTime += Time.deltaTime;
        if (finalizeTime > 2)
        {
            GameObject repairedObject = GameObject.FindGameObjectWithTag("repairedObject");
            Destroy(repairedObject);
            GameObject repairPart = GameObject.FindGameObjectWithTag("repairPart");
            Destroy(repairPart);
            try
            {
                GameObject ikeaManual = GameObject.FindGameObjectWithTag("ikeaManual");
                Destroy(ikeaManual);
            } catch (UnityException)
            {
                // Ikea manual are not mandatory
            }
            finalizingCurrentPuzzle = false;
            initializingNextPuzzle = true;
            currentSolution = null;
        }
    }

    private GameObject getChildWithTag(GameObject parent, string tag)
    {
        foreach (Transform tr in parent.transform)
        {
            if (tr.tag == tag)
            {
                return tr.gameObject;
            }
        }
        throw new System.Exception("The solution " + currentPuzzleIndex + " is incomplete");
    }
}
