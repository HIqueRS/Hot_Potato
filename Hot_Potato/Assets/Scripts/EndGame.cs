using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
			
			
		}
		Ending();
		Events();
		
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

	}

	private void Win()
	{

	}

	private void Events()
	{
		delay += Time.deltaTime;
		if(time > timeOfGame/3)
		{
			Debug.Log(delay + " delay");
			Debug.Log(delayWind + " delayWind");
			
			if (delay > delayWind )
			{
				//changeBar.function(Random.Range(0, 1));
				//call a animacao
				leftWindow.SetTrigger("teste");
				rightWindow.SetTrigger("Open");
				Debug.Log("ue");
				delayWind = Random.Range(min, max);
				delay = 0;
			}
		}
	}
}
