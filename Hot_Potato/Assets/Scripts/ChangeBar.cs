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
	private float decreaseLuz;
	private float decreaseFogo;
	private bool[] taLigadaLuz;
	private bool[] taLigadoFogo;
	private static int sala = 0;
	private static int cozinha = 1;
	private bool primeiraCoisa = true;
	private float[] diminuiAlfabg;
	private float[] diminuiAlfaim;

	

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

		maxIntensityLuz[0] = iluzinha[0].intensity;
		maxIntensityLuz[cozinha] = iluzinha[cozinha].intensity;
		maxIntensityFogo[sala] = fogo[sala].intensity;
		maxIntensityFogo[cozinha] = fogo[cozinha].intensity;

		manager = GameObject.FindGameObjectWithTag("GameController");
		game = Resources.Load<GameManager>("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
		MudaLuzEBarra(sala);
		MudaLuzEBarra(cozinha);
		MudaFogoEBarra(sala);
		MudaFogoEBarra(cozinha);

		TestaIntensityLuzes();
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

	void TestaIntensityLuzes()
	{
		if (iluzinha[sala].intensity <= 0)
		{
			iluzinha[sala].intensity = 0;
			bgFogo[sala].color = new Color(bgFogo[sala].color.r, bgFogo[sala].color.g, bgFogo[sala].color.b, DiminuiAlfaBG(sala));
			imageFogo[sala].color = new Color(imageFogo[sala].color.r, imageFogo[sala].color.g, imageFogo[sala].color.b, DiminuiAlfaIM(sala));
		}
		else
		{
			bgFogo[sala].color = new Color(bgFogo[sala].color.r, bgFogo[sala].color.g, bgFogo[sala].color.b, 1);
			imageFogo[sala].color = new Color(imageFogo[sala].color.r, imageFogo[sala].color.g, imageFogo[sala].color.b, 1);

			diminuiAlfabg[sala] = diminuiAlfaim[sala] = 1;
		}
		if (iluzinha[cozinha].intensity <= 0)
		{
			iluzinha[cozinha].intensity = 0;
			bgFogo[cozinha].color = new Color(bgFogo[cozinha].color.r, bgFogo[cozinha].color.g, bgFogo[cozinha].color.b, DiminuiAlfaBG(cozinha));
			imageFogo[cozinha].color = new Color(imageFogo[cozinha].color.r, imageFogo[cozinha].color.g, imageFogo[cozinha].color.b, DiminuiAlfaIM(cozinha));
		}
		else
		{
			bgFogo[cozinha].color = new Color(bgFogo[cozinha].color.r, bgFogo[cozinha].color.g, bgFogo[cozinha].color.b, 1);
			imageFogo[cozinha].color = new Color(imageFogo[cozinha].color.r, imageFogo[cozinha].color.g, imageFogo[cozinha].color.b, 1);

			diminuiAlfabg[cozinha] = diminuiAlfaim[cozinha] = 1;
		}
	}
	float DiminuiAlfaBG(int comodo)
	{
		if (diminuiAlfabg[comodo] > 0)
		{
			diminuiAlfabg[comodo] -= 0.5f * Time.deltaTime;
		}

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
