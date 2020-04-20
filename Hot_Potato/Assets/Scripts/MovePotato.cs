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

                    Debug.Log(hit.transform.gameObject.name);
					if(man.inMinigame)
					{
						man.luzCozinha = false;
						man.luzSala = false;
						man.fogoCozinha = false;
						man.fogoSala = false;
					}
					else if (hit.transform.gameObject.tag == "LuzCozinha")
                    {
                        man.luzCozinha = true;
                        man.luzSala = false;
                        man.fogoCozinha = false;
                        man.fogoSala = false;


                    }
                    else if(hit.transform.gameObject.tag == "LuzSala")
                    {
                        man.luzCozinha = false;
                        man.luzSala = true;
                        man.fogoCozinha = false;
                        man.fogoSala = false;
                    }
                    else if (hit.transform.gameObject.tag == "FogoCozinha")
                    {
                        man.luzCozinha = false;
                        man.luzSala = false;
                        man.fogoCozinha = true;
                        man.fogoSala = false;
                    }
                    else if (hit.transform.gameObject.tag == "FogoSala")
                    {
                        man.luzCozinha = false;
                        man.luzSala = false;
                        man.fogoCozinha = false;
                        man.fogoSala = true;
                    }
                    else
                    {
                        man.luzCozinha = false;
                        man.luzSala = false;
                        man.fogoCozinha = false;
                        man.fogoSala = false;
                    }
                }
            }
        }
    }
}
