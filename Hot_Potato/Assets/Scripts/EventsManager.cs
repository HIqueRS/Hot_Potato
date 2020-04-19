using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventsManager : MonoBehaviour
{

	private float timerControl;
	private float startTime;
	public int duracao;
	private bool[] taLigadaLuz;
	private bool[] taLigadoFogo;

    // Start is called before the first frame update
    void Start()
    {
		taLigadaLuz = new bool[2];
		taLigadoFogo = new bool[2];

		taLigadaLuz[0] = true;
		taLigadaLuz[1] = false;
		taLigadoFogo[0] = true;
		taLigadoFogo[1] = true;

		startTime = Mathf.RoundToInt(Time.timeSinceLevelLoad);
    }

    // Update is called once per frame
    void Update()
    {
		timerControl = Mathf.RoundToInt(Time.timeSinceLevelLoad - startTime);

		if (timerControl >= duracao * 60)
		{
			//chegou no fim
		}
	}
}
