using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MovePotato : MonoBehaviour
{
    public Camera cam;
    public NavMeshAgent agent;
    public GameManager man;
	private bool holdUp;

    // Update is called once per frame
    private void Start()
    {
        man = Resources.Load<GameManager>("GameManager");
		holdUp = false;
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
						holdUp = false;
					}
					else if (hit.transform.gameObject.tag == "LuzCozinha" )
                    {
						if(!holdUp)
						{
							man.luzCozinha = true;
							man.luzSala = false;
							man.fogoCozinha = false;
							man.fogoSala = false;
							holdUp = true;
						}
						else
						{
							holdUp = false;
						}
                       

					}
                    else if(hit.transform.gameObject.tag == "LuzSala")
                    {
						if (!holdUp)
						{
							man.luzCozinha = false;
							man.luzSala = true;
							man.fogoCozinha = false;
							man.fogoSala = false;
							holdUp = true;
						}
						else
						{
							holdUp = false;
						}

					}
                    else if (hit.transform.gameObject.tag == "FogoCozinha")
                    {
						if (!holdUp)
						{
							man.luzCozinha = false;
							man.luzSala = false;
							man.fogoCozinha = true;
							man.fogoSala = false;
							holdUp = true;
						}
						else
						{
							holdUp = false;
						}

					}
                    else if (hit.transform.gameObject.tag == "FogoSala")
                    {
						if (!holdUp)
						{
							man.luzCozinha = false;
							man.luzSala = false;
							man.fogoCozinha = false;
							man.fogoSala = true;
							holdUp = true;
						}
						else
						{
							holdUp = false;
						}

					}
                    else
                    {
                        man.luzCozinha = false;
                        man.luzSala = false;
                        man.fogoCozinha = false;
                        man.fogoSala = false;
						holdUp = false;
                    }
                }
            }
        }
		
    }

	private void LateUpdate()
	{
		
	}
}
