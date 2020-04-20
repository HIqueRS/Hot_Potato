using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventsManager : MonoBehaviour
{
	private bool start = false;
	private float timerControl;
	private float startTime = 0;
	public int duracao;
	private bool[] taLigadaLuz;
	private bool[] taLigadoFogo;
	private GameManager game;

    // Start is called before the first frame update
    void Start()
    {
		taLigadaLuz = new bool[2];
		taLigadoFogo = new bool[2];

		game = Resources.Load<GameManager>("GameManager");

		startTime = Mathf.RoundToInt(Time.timeSinceLevelLoad);
    }

    // Update is called once per frame
    void Update()
    {

		if (game.iniciou && !start)
		{
			startTime = Mathf.RoundToInt(Time.timeSinceLevelLoad);
			start = true;
		}
		timerControl = Mathf.RoundToInt(Time.timeSinceLevelLoad - startTime);

		if (timerControl >= duracao * 60)
		{
			//chegou no fim
		}
	}
}
