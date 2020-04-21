using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SliderManager : MonoBehaviour
{
	private bool aumentando;		
	public Slider ligarCoisinhas;
	public float tamanhoSlider;
	private float minimo;
	private float maximo;
	public Image areaCerta;
	public Image frio;
	public Image quente;
	private float posAreaCerta;
	[Tooltip("em float, 1 ja fica consideravelmente rapido")]
	public float velSlider;
	private GameObject gManager;
	public GameObject painel;
	public GameObject painelErro;


	private int lugar, tipo;
	private bool chamou = false;

	private bool chamou1 = true;

	private GameManager gamMan;

	// Start is called before the first frame update
	void Start()
    {
		aumentando = true;

		gamMan = Resources.Load<GameManager>("GameManager");

		gManager = GameObject.FindGameObjectWithTag("GameController");
	}

	// Update is called once per frame
	void Update()
	{
		VaieVolta();

		
		

		if (chamou)
		{
			if (chamou1)
			{
				minimo = Random.Range(0.2f, 0.8f);
				maximo = minimo + (tamanhoSlider / 1000);

				frio.fillAmount = minimo;
				quente.fillAmount = maximo;

				posAreaCerta = minimo * tamanhoSlider;


				

				areaCerta.rectTransform.anchoredPosition = new Vector3(posAreaCerta, 0, 0);


				chamou1 = false;
			}

			if (Input.GetMouseButtonDown(0))
			{
				if (ligarCoisinhas.value >= minimo && ligarCoisinhas.value <= maximo)
				{
					if (tipo == 0)
					{
						gManager.GetComponent<ChangeBar>().iluzinha[lugar].intensity = 1.3f;

						painel.SetActive(false);

						chamou = false;
					}
					if (tipo == 1)
					{
						gManager.GetComponent<ChangeBar>().fogo[lugar].intensity = 1.6f;

						painel.SetActive(false);

						chamou = false;
					}

					ligarCoisinhas.value = 0;
					gamMan.jogoComecou = true;
					gamMan.inMinigame = false;
					gamMan.luzCozinha = false;
					gamMan.luzSala = false;
					gamMan.fogoCozinha = false;
					gamMan.fogoSala = false;
				}
				else
				{

					painel.SetActive(false);

					painelErro.SetActive(true);

					chamou = false;			

					ligarCoisinhas.value = 0;
				}

				chamou1 = true;

				posAreaCerta = 0;
				minimo = 0;
				maximo = 0;
			}
		}

	}

	void VaieVolta()
	{
		if (aumentando)
		{
			ligarCoisinhas.value += Time.deltaTime * (velSlider);
		}
		else if (!aumentando)
		{
			ligarCoisinhas.value -= Time.deltaTime * (velSlider);
		}

		if (ligarCoisinhas.value >= 1)
		{
			aumentando = false;
		}
		else if (ligarCoisinhas.value <= 0)
		{
			aumentando = true;
		}
	}

	public void ChamaMiniGame(int oQue, int onde)
	{

		if (chamou1)
		{
			painel.SetActive(true);

			chamou = true;

			tipo = oQue;
			lugar = onde;

			ligarCoisinhas.value = 0;

			gamMan.jogoComecou = false;
			gamMan.inMinigame = true;
		}
		
	}
	
	public void AcertouBotao()
	{
		chamou = false;

		painelErro.SetActive(false);

		ligarCoisinhas.value = 0;

		if (tipo == 0)
		{
			gManager.GetComponent<ChangeBar>().iluzinha[lugar].intensity = 2;

			painel.SetActive(false);

			chamou = false;
		}
		if (tipo == 1)
		{
			gManager.GetComponent<ChangeBar>().fogo[lugar].intensity = 2;

			painel.SetActive(false);

			chamou = false;
		}

		gamMan.jogoComecou = true;
	}
}
