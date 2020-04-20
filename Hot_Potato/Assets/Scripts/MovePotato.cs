using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MovePotato : MonoBehaviour
{
    public Camera cam;
    public NavMeshAgent agent;
    public GameManager man;

    // Update is called once per frame
    private void Start()
    {
        man = Resources.Load<GameManager>("GameManager");
    }

    void Update()
    {
        if(man.jogoComecou)
        {

            if(Input.GetMouseButtonDown(0))
            {
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

           

                if(Physics.Raycast(ray,out hit))
                {
                    agent.SetDestination(hit.point);
                }
            }
        }
    }
}
