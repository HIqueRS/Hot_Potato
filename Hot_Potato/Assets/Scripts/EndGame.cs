using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{

    private GameManager gamMan;
    private float time;
    public float timeOfGame;
    // Start is called before the first frame update
    void Start()
    {
        time = 0;
        gamMan = Resources.Load<GameManager>("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        if(gamMan.iniciou)
        {
            time += Time.deltaTime;
            if(gamMan.intensityFogo[0] <=0 && gamMan.intensityFogo[1] <=0)
            {
                //gameover
                Debug.Log("GameOver");

            }

            if(time >= timeOfGame)
            {
                Debug.Log("Ganhou");
            }

        }
    }
}
