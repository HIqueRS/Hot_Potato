using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{

    private GameManager gamMan;
    private float time;
    public float timeOfGame;
	public ChangeBar changeBar;
	private float delayWind;
	private float delay;
	public float min;
	public float max;
	public Animator leftWindow;
	public Animator rightWindow;
	public Animator door;

	//public Animation
	
    // Start is called before the first frame update
    void Start()
    {
        time = 0;
		delay = 0;
		gamMan = Resources.Load<GameManager>("GameManager");
		changeBar = gameObject.GetComponent<ChangeBar>();

		timeOfGame *= 60;

		delayWind = Random.Range(min, max);
    }

    // Update is called once per frame
    void Update()
    {
		
		if (gamMan.iniciou)
		{
			Ending();
			Events();

		}
		

	}

	private void Ending()
	{		
		time += Time.deltaTime;
		if (gamMan.intensityFogo[0] <= 0 && gamMan.intensityFogo[1] <= 0)
		{			
			GameOver();
		}

		if (time >= timeOfGame)
		{			
			Win();
		}		
	}

	private void GameOver()
	{
		SceneManager.LoadScene(1);
	}

	private void Win()
	{
		SceneManager.LoadScene(2);
	}

	private void Events()
	{
		delay += Time.deltaTime;
		if(time > timeOfGame/3)
		{
			
			
			if (delay > delayWind )
			{
				//changeBar.function(Random.Range(0, 1));
				//call a animacao
				if(Random.Range(0,2) == 0)
				{
					leftWindow.SetTrigger("Open");
					rightWindow.SetTrigger("Open");
					changeBar.Evento(0, 0.25f);
					
				}
				else
				{
					door.SetTrigger("Open");
					changeBar.Evento(1, 0.25f);
				}
				
				
				Debug.Log("ue");
				delayWind = Random.Range(min, max);
				delay = 0;
			}
		}
	}
}
