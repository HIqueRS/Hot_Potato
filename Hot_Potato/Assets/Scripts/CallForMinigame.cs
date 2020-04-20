using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallForMinigame : MonoBehaviour
{

    private GameManager gamMan;
	private GameObject gManager;

	// Start is called before the first frame update
	void Start()
    {
        gamMan = Resources.Load<GameManager>("GameManager");
		gManager = GameObject.FindGameObjectWithTag("GameController");
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Potato")
        {
            if (gameObject.tag == "LuzCozinha")
            {
                if (gamMan.luzCozinha)
                {
					gManager.GetComponent<SliderManager>().ChamaMiniGame(0, 1);
                    Debug.Log("aaa");
                }
            }
            else if (gameObject.tag == "LuzSala")
            {
                if (gamMan.luzSala)
                {
					gManager.GetComponent<SliderManager>().ChamaMiniGame(0, 0);
				}
                    //call aqui
                    Debug.Log("aaa");
               
            }
            else if (gameObject.tag == "FogoCozinha")
            {
                if (gamMan.fogoCozinha)
                {
					gManager.GetComponent<SliderManager>().ChamaMiniGame(1, 1);
				}
                    //call aqui
                    Debug.Log("aaa");
                
            }
            else if (gameObject.tag == "FogoSala")
            {
                if (gamMan.fogoSala)
                {
					gManager.GetComponent<SliderManager>().ChamaMiniGame(1, 0);
				}
                    //call aqui
                    Debug.Log("aaa");
               
            }
        }
    }

	

  
}
