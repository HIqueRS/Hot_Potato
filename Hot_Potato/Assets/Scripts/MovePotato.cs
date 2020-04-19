using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MovePotato : MonoBehaviour
{
    public Camera cam;
    public NavMeshAgent agent;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            Debug.Log("fiu");

            if(Physics.Raycast(ray,out hit))
            {
                agent.SetDestination(hit.point);
            }
        }
    }
}
