using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ChangeBar : MonoBehaviour
{

    public Image[] imageLuz;
    public Image[] imageFogo;
    private GameManager game;
    public Light[] luz;
	public Light[] fogo;
    private float[] maxIntensityLuz;
    private float[] maxIntensityFogo;
	private GameObject manager;
	private float decreaseTime = 0.1f;
	private bool[] taLigadaLuz;
	private bool[] taLigadoFogo;

	// Start is called before the first frame update
	void Start()
	{
		taLigadaLuz = new bool[2];
		taLigadoFogo = new bool[2];

		maxIntensityFogo = new float[2];
		maxIntensityLuz = new float[2];

        maxIntensityLuz[0] = luz[0].intensity;
		maxIntensityLuz[1] = luz[1].intensity;
		maxIntensityFogo[0] = fogo[0].intensity;
		maxIntensityFogo[1] = fogo[1].intensity;

		manager = Resources.Load<GameObject>("GameManager");
		game = Resources.Load<GameManager>("GameManager");
    }

    // Update is called once per frame
    void Update()
    {

		MudaLuzEBarra(0);
		MudaLuzEBarra(1);
		MudaFogoEBarra(0);
		MudaFogoEBarra(1);
		
    }

	void MudaLuzEBarra(int num)
	{
        luz[num].intensity -= decreaseTime * Time.deltaTime;
        game.intensityLuz[num] = imageLuz[num].fillAmount = luz[num].intensity/ maxIntensityLuz[num];
	}
	void MudaFogoEBarra(int num)
	{
        fogo[num].intensity -= decreaseTime * Time.deltaTime;
        game.intensityFogo[num] = imageFogo[num].fillAmount = fogo[num].intensity/ maxIntensityFogo[num];
	}
}
