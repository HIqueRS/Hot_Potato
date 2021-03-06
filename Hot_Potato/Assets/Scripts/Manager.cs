﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Manager : MonoBehaviour
{
    private GameManager gamMan;
    private CamManager camMan;
    
    private void Awake()
    {
        gamMan = Resources.Load<GameManager>("GameManager");
        camMan = Resources.Load<CamManager>("CamManagement");
        gamMan.jogoComecou = false;
        camMan.camsPriority[0] = 10;
        camMan.camsPriority[1] = 15;
        camMan.camsPriority[2] = 10;
        camMan.camsPriority[3] = 10;
        

        gamMan.fogoSala = false;
        gamMan.luzSala = false;
        gamMan.luzCozinha = false;
        gamMan.fogoCozinha = false;

		gamMan.inMinigame = false;
		gamMan.iniciou = false;
        //Debug.Log("ah meu");
    }
}
