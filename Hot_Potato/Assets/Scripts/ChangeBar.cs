using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ChangeBar : MonoBehaviour
{

	public Image[] bgFogo;
	public Image[] imageLuz;
	public Image[] imageFogo;
	private GameManager game;
	public Light[] iluzinha;
	public Light[] fogo;
	private float[] maxIntensityLuz;
	private float[] maxIntensityFogo;
	private GameObject manager;
	public float decreaseLuz;
	private float decreaseFogo;
	private bool[] taLigadaLuz;
	private bool[] taLigadoFogo;
	private static readonly int sala = 0;
	private static readonly int cozinha = 1;
	private float[] diminuiAlfabg;
	private float[] diminuiAlfaim;
	private bool iniciou = false;
	private bool lareiraAcesa = false;
	private bool fogaoAceso = false;

	private bool ligouCozinha = false;

	// Start is called before the first frame update
	void Start()
	{
		taLigadaLuz = new bool[2];
		taLigadoFogo = new bool[2];

		maxIntensityFogo = new float[2];
		maxIntensityLuz = new float[2];

		diminuiAlfaim = new float[2];
		diminuiAlfabg = new float[2];

		diminuiAlfabg[sala] = 1;
		diminuiAlfabg[sala] = 1;
		diminuiAlfaim[cozinha] = 1;
		diminuiAlfaim[cozinha] = 1;

		maxIntensityLuz[sala] = iluzinha[sala].intensity;
		maxIntensityLuz[cozinha] = iluzinha[cozinha].intensity;
		maxIntensityFogo[sala] = fogo[sala].intensity;
		maxIntensityFogo[cozinha] = fogo[cozinha].intensity;

		iluzinha[cozinha].intensity = 0;
		fogo[sala].intensity = 0;
		fogo[cozinha].intensity = 0;

		imageLuz[cozinha].fillAmount = 0;
		imageFogo[cozinha].fillAmount = 0;
		imageFogo[sala].fillAmount = 0;

		taLigadaLuz[sala] = true;
		taLigadaLuz[cozinha] = false;
		taLigadoFogo[sala] = false;
		taLigadoFogo[cozinha] = false;

		manager = GameObject.FindGameObjectWithTag("GameController");
		game = Resources.Load<GameManager>("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
		

		if (fogaoAceso && lareiraAcesa)
		{
			iniciou = true;
		}

		game.iniciou = iniciou;

		if(iniciou)
		{


			MudaIntensidadeLuz();


		}
		MudaIntensidadeLuz();

		TestaIntensityLuzes();

		TestaIntensityFogo();
		//iluzinha[sala].intensity -= 0.1f;
	}

	void MudaIntensidadeLuz()
	{
		if (iluzinha[sala].intensity > 0)
		{
			MudaLuzEBarra(sala);
		}

		if (iluzinha[cozinha].intensity > 0)
		{
			MudaLuzEBarra(cozinha);
		}

		if (fogo[sala].intensity > 0)
		{
			MudaFogoEBarra(sala);
		}

		if (fogo[cozinha].intensity > 0)
		{
			MudaFogoEBarra(cozinha);
		}
	}

	void MudaLuzEBarra(int num)
	{
		iluzinha[num].intensity -= decreaseLuz * Time.deltaTime;
		game.intensityLuz[num] = imageLuz[num].fillAmount = iluzinha[num].intensity / maxIntensityLuz[num];
	}

	void MudaFogoEBarra(int num)
	{
        fogo[num].intensity -= decreaseFogo * Time.deltaTime;
        game.intensityFogo[num] = imageFogo[num].fillAmount = fogo[num].intensity/ maxIntensityFogo[num];
	}

	void TestaIntensityFogo()
	{
		if (fogo[sala].intensity > 0)
		{
			if (!iniciou)
			{
				lareiraAcesa = true;
			}
		}

		if (fogo[cozinha].intensity > 0)
		{
			if (!iniciou)
			{
				fogaoAceso = true;
			}
		}
	}

	void TestaIntensityLuzes()
	{
		if (iluzinha[sala].intensity <= 0 || (!iniciou))
		{

			if (iniciou)
			{
				iluzinha[sala].intensity = 0;

				bgFogo[sala].color = new Color(bgFogo[sala].color.r, bgFogo[sala].color.g, bgFogo[sala].color.b, DiminuiAlfaBG(sala));
				imageFogo[sala].color = new Color(imageFogo[sala].color.r, imageFogo[sala].color.g, imageFogo[sala].color.b, DiminuiAlfaIM(sala));

				taLigadaLuz[sala] = false;
			}
			else if (iniciou && ligouCozinha)
			{
				bgFogo[sala].color = new Color(bgFogo[sala].color.r, bgFogo[sala].color.g, bgFogo[sala].color.b, 0);
			}
			
			
		}
		else
		{
			bgFogo[sala].color = new Color(bgFogo[sala].color.r, bgFogo[sala].color.g, bgFogo[sala].color.b, 1);
			imageFogo[sala].color = new Color(imageFogo[sala].color.r, imageFogo[sala].color.g, imageFogo[sala].color.b, 1);

			diminuiAlfabg[sala] = diminuiAlfaim[sala] = 1;

			taLigadaLuz[sala] = true;
		}
		if (iluzinha[cozinha].intensity <= 0)
		{
			iluzinha[cozinha].intensity = 0;
			bgFogo[cozinha].color = new Color(bgFogo[cozinha].color.r, bgFogo[cozinha].color.g, bgFogo[cozinha].color.b, DiminuiAlfaBG(cozinha));
			imageFogo[cozinha].color = new Color(imageFogo[cozinha].color.r, imageFogo[cozinha].color.g, imageFogo[cozinha].color.b, DiminuiAlfaIM(cozinha));

			taLigadaLuz[cozinha] = false;
		}
		else
		{
			bgFogo[cozinha].color = new Color(bgFogo[cozinha].color.r, bgFogo[cozinha].color.g, bgFogo[cozinha].color.b, 1);
			imageFogo[cozinha].color = new Color(imageFogo[cozinha].color.r, imageFogo[cozinha].color.g, imageFogo[cozinha].color.b, 1);

			diminuiAlfabg[cozinha] = diminuiAlfaim[cozinha] = 1;

			taLigadaLuz[cozinha] = true;
		}
	}

	float DiminuiAlfaBG(int comodo)
	{
		
		diminuiAlfabg[comodo] -= 0.5f * Time.deltaTime;
		

		return diminuiAlfabg[comodo];
	}

	float DiminuiAlfaIM(int comodo)
	{
		if (diminuiAlfaim[comodo] > 0)
		{
			diminuiAlfaim[comodo] -= 0.5f * Time.deltaTime;
		}

		return diminuiAlfaim[comodo];
	}
}
