using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ChangeBar : MonoBehaviour
{

	public Image[] bgFogo;
	public Image[] frame;
	public Image[] imageLuz;
	public Image[] imageFogo;
	private GameManager game;
	public Light[] iluzinha;
	public Light[] fogo;
	private float[] maxIntensityLuz;
	private float[] maxIntensityFogo;
	private GameObject manager;
	private float[] decreaseLuz;
	private float[] decreaseFogo;
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
	private bool tutorial = true;

	 public float velNormalF;
	 public float velNormalL;

	float time;



	// Start is called before the first frame update
	void Start()
	{
		taLigadaLuz = new bool[2];
		taLigadoFogo = new bool[2];

		maxIntensityFogo = new float[2];
		maxIntensityLuz = new float[2];

		diminuiAlfaim = new float[2];
		diminuiAlfabg = new float[2];

		decreaseLuz = new float[2];
		decreaseFogo = new float[2];

		decreaseLuz[sala] = velNormalL;
		decreaseLuz[cozinha] = velNormalL;
		decreaseFogo[sala] = velNormalF;
		decreaseFogo[cozinha] = velNormalF;

		diminuiAlfabg[sala] = 1;
		diminuiAlfabg[cozinha] = 1;
		diminuiAlfaim[sala] = 1;
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

		time = 0;

		manager = GameObject.FindGameObjectWithTag("GameController");
		game = Resources.Load<GameManager>("GameManager");
	}

	// Update is called once per frame
	void Update()
	{


		if (fogaoAceso && lareiraAcesa)
		{
			iniciou = true;
			tutorial = false;
			game.iniciou = iniciou;
		}
		else
		{
			tutorial = true;
		}



		if (tutorial)
		{
			Tutorial(false);
		}

		VelNormal();

		MudaIntensidadeLuz();

		TestaIntensityLuzes();

		TestaIntensityFogo();
		//iluzinha[sala].intensity -= 0.1f;
	}

	void MudaIntensidadeLuz()
	{
		if (iluzinha[sala].intensity > 0)
		{
			if (!tutorial)
			{
				iluzinha[sala].intensity -= decreaseLuz[sala] * Time.deltaTime;
				game.intensityLuz[sala] = imageLuz[sala].fillAmount = iluzinha[sala].intensity / maxIntensityLuz[sala];
			}
		}

		if (iluzinha[cozinha].intensity > 0)
		{
			if (!tutorial)
			{
				iluzinha[cozinha].intensity -= decreaseLuz[cozinha] * Time.deltaTime;
				game.intensityLuz[cozinha] = imageLuz[cozinha].fillAmount = iluzinha[cozinha].intensity / maxIntensityLuz[cozinha];
			}
		}

		if (fogo[sala].intensity > 0)
		{
			fogo[sala].intensity -= decreaseFogo[sala] * Time.deltaTime;
			game.intensityFogo[sala] = imageFogo[sala].fillAmount = fogo[sala].intensity / maxIntensityFogo[sala];
		}

		if (fogo[cozinha].intensity > 0)
		{
			fogo[cozinha].intensity -= decreaseFogo[cozinha] * Time.deltaTime;
			game.intensityFogo[cozinha] = imageFogo[cozinha].fillAmount = fogo[cozinha].intensity / maxIntensityFogo[cozinha];
		}
	}

	void TestaIntensityFogo()
	{
		if (fogo[sala].intensity > 0)
		{
			if (!iniciou)
			{
				lareiraAcesa = true;
			}
			imageFogo[sala].fillAmount = fogo[sala].intensity / maxIntensityFogo[sala];
		}

		if (fogo[cozinha].intensity > 0)
		{
			if (!iniciou)
			{
				fogaoAceso = true;
			}
			imageFogo[cozinha].fillAmount = fogo[cozinha].intensity / maxIntensityFogo[cozinha];
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
				frame[sala].color = new Color(frame[sala].color.r, frame[sala].color.g, frame[sala].color.b, DiminuiAlfaBG(sala));

				taLigadaLuz[sala] = false;
			}
			else if (!iniciou)
			{
				if (!ligouCozinha)
				{
					bgFogo[sala].color = new Color(bgFogo[sala].color.r, bgFogo[sala].color.g, bgFogo[sala].color.b, 0);
					frame[sala].color = new Color(frame[sala].color.r, frame[sala].color.g, frame[sala].color.b, 0);

				}
				else
				{
					Tutorial(ligouCozinha);
				}
			}


		}
		else
		{
			bgFogo[sala].color = new Color(bgFogo[sala].color.r, bgFogo[sala].color.g, bgFogo[sala].color.b, 1);
			imageFogo[sala].color = new Color(imageFogo[sala].color.r, imageFogo[sala].color.g, imageFogo[sala].color.b, 1);
			frame[sala].color = new Color(frame[sala].color.r, frame[sala].color.g, frame[sala].color.b, 1);

			diminuiAlfabg[sala] = diminuiAlfaim[sala] = 1;

			taLigadaLuz[sala] = true;
		}
		if (iluzinha[cozinha].intensity <= 0)
		{
			iluzinha[cozinha].intensity = 0;
			bgFogo[cozinha].color = new Color(bgFogo[cozinha].color.r, bgFogo[cozinha].color.g, bgFogo[cozinha].color.b, DiminuiAlfaBG(cozinha));
			frame[cozinha].color = new Color(frame[cozinha].color.r, frame[cozinha].color.g, frame[cozinha].color.b, DiminuiAlfaBG(cozinha));
			imageFogo[cozinha].color = new Color(imageFogo[cozinha].color.r, imageFogo[cozinha].color.g, imageFogo[cozinha].color.b, DiminuiAlfaIM(cozinha));
			

			taLigadaLuz[cozinha] = false;
		}
		else
		{
			bgFogo[cozinha].color = new Color(bgFogo[cozinha].color.r, bgFogo[cozinha].color.g, bgFogo[cozinha].color.b, 1);
			frame[cozinha].color = new Color(frame[cozinha].color.r, frame[cozinha].color.g, frame[cozinha].color.b, 1);
			imageFogo[cozinha].color = new Color(imageFogo[cozinha].color.r, imageFogo[cozinha].color.g, imageFogo[cozinha].color.b, 1);

			diminuiAlfabg[cozinha] = diminuiAlfaim[cozinha] = 1;

			taLigadaLuz[cozinha] = true;

			if (!iniciou)
			{
				ligouCozinha = true;
			}
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

	void Tutorial(bool luzCoz)
	{

		if (luzCoz)
		{
			frame[sala].color = new Color(frame[sala].color.r, frame[sala].color.g, frame[sala].color.b, 1);
			bgFogo[sala].color = new Color(bgFogo[sala].color.r, bgFogo[sala].color.g, bgFogo[sala].color.b, 1);
			game.intensityLuz[cozinha] = imageLuz[cozinha].fillAmount = 1;
		}
		if (fogaoAceso)
		{
			game.intensityFogo[cozinha] = imageFogo[cozinha].fillAmount = 1;
		}
		if (lareiraAcesa)
		{
			game.intensityFogo[sala] = imageFogo[sala].fillAmount = fogo[sala].intensity / maxIntensityFogo[sala];
		}



		game.intensityLuz[sala] = imageLuz[sala].fillAmount = 1;

	}

	public void Evento(int onde, float vel)
	{
		if (onde == 0)
		{
			decreaseFogo[sala] = vel;
			decreaseLuz[sala] = vel;
		}
		else if (onde == 1)
		{
			decreaseFogo[cozinha] = vel;
			decreaseLuz[cozinha] = vel;
		}

		time = 0;
	}

	void VelNormal()
	{
		time += Time.deltaTime;

		if (time >= 5)
		{
			decreaseFogo[sala] = velNormalF;
			decreaseFogo[cozinha] = velNormalF;

			decreaseLuz[sala] = velNormalL;
			decreaseLuz[cozinha] = velNormalL;
		}
	}
}
