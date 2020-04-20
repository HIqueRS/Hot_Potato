using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallForMinigame : MonoBehaviour
{

    private GameManager gamMan;

    // Start is called before the first frame update
    void Start()
    {
        gamMan = Resources.Load<GameManager>("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {

       
        if (other.gameObject.tag == "Potato")
        {
            if (gameObject.tag == "LuzCozinha")
            {
                if (gamMan.luzCozinha)
                {
                    //call aqui
                    Debug.Log("aaa");
                }
            }
            else if (gameObject.tag == "LuzSala")
            {
                if (gamMan.luzSala)
                {
                    //call aqui
                }
            }
            else if (gameObject.tag == "FogoCozinha")
            {
                if (gamMan.fogoCozinha)
                {
                    //call aqui
                }
            }
            else if (gameObject.tag == "FogoSala")
            {
                if (gamMan.fogoSala)
                {
                    //call aqui
                }
            }
        }
    }

  
}
