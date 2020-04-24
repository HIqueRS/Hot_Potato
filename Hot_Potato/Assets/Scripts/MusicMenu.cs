using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicMenu : MonoBehaviour
{

    public AudioSource musicMenu;
    public AudioSource musicGame;
    private GameManager gamMan;
    // Start is called before the first frame update
    void Start()
    {
        gamMan = Resources.Load<GameManager>("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        if(gamMan.jogoComecou)
        {
            musicMenu.volume -= 0.19875f*Time.deltaTime;
            if(musicGame.volume <= 1)
            {
                musicGame.volume += 0.19875f*Time.deltaTime;
            }
           
        }
    }

    
}
