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
	private float posAreaCerta;
	[Tooltip("em float, 1 ja fica consideravelmente rapido")]
	public float velSlider;
	private GameObject gManager;
	public GameObject painel;
	public GameObject painelErro;
	public Image painelErrou;

	private bool aumentaAlfa = false;

	private int lugar, tipo;
	private bool errou = false;
	private float piscaPisca;
	private bool chamou = false;
	private bool desligaTudo;

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

				posAreaCerta = minimo * tamanhoSlider;

				//areaCerta.rectTransform.Translate(new Vector3(posAreaCerta, 0, 0));

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
						gManager.GetComponent<ChangeBar>().fogo[lugar].intensity = 1.3f;

						painel.SetActive(false);

						chamou = false;
					}

					ligarCoisinhas.value = 0;
					gamMan.jogoComecou = true;
				}
				else
				{
					errou = true;

					painel.SetActive(false);

					painelErro.SetActive(true);

					chamou = false;

					piscaPisca = 0.6f;

					painelErrou.color = new Color(painelErrou.color.r, painelErrou.color.g, painelErrou.color.b, piscaPisca);					

					ligarCoisinhas.value = 0;
				}

				chamou1 = true;

				posAreaCerta = 0;
				minimo = 0;
				maximo = 0;
			}
		}
		if (errou)
		{
			PiscaPanel();
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
		}
		
	}

	void PiscaPanel()
	{
		if (piscaPisca > 0.3f && !aumentaAlfa)
		{
			piscaPisca -= 0.6f * Time.deltaTime;

			Debug.Log(piscaPisca);
		}
		else if (piscaPisca <= 0.6f && aumentaAlfa)
		{
			piscaPisca += 0.6f * Time.deltaTime;

		}

		if (piscaPisca >= 0.6)
		{
			aumentaAlfa = false;
		}
		else if (piscaPisca <= 0.3f)
		{
			aumentaAlfa = true;
		}
		
		painelErrou.color = new Color(painelErrou.color.r, painelErrou.color.g, painelErrou.color.b, piscaPisca);
	}
	
	public void AcertouBotao()
	{
		chamou = false;

		painelErro.SetActive(false);

		ligarCoisinhas.value = 0;

		errou = false;

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
