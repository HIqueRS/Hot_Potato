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

	private int lugar, tipo;
	private bool errou = false;
	private float piscaPisca;


	// Start is called before the first frame update
	void Start()
    {
		aumentando = true;

		minimo = Random.Range(0.2f, 0.6f);
		maximo = minimo + (tamanhoSlider / 1000);

		posAreaCerta = minimo * tamanhoSlider;

		areaCerta.rectTransform.Translate(new Vector3(posAreaCerta, 0, 0));

		gManager = GameObject.FindGameObjectWithTag("GameController");
	}

	// Update is called once per frame
	void Update()
	{
		VaieVolta();
		if (Input.GetMouseButtonDown(0))
		{
			if (ligarCoisinhas.value >= minimo && ligarCoisinhas.value <= maximo)
			{
				if (tipo == 0)
				{
					gManager.GetComponent<ChangeBar>().iluzinha[lugar].intensity = 2;

					painel.SetActive(false);
				}
				if (tipo == 1)
				{
					gManager.GetComponent<ChangeBar>().fogo[lugar].intensity = 2;

					painel.SetActive(false);
				}
			}
			else
			{
				errou = true;

				painelErro.SetActive(true);
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
		painel.SetActive(true);

		tipo = oQue;
		lugar = onde;
	}

	void PiscaPanel()
	{
		if (piscaPisca > 0.3f)
		{
			piscaPisca -= 0.05f * Time.deltaTime;
		}
		else
		{
			piscaPisca += 0.05f * Time.deltaTime;
		}
		
		painelErrou.color = new Color(painelErrou.color.r, painelErrou.color.g, painelErrou.color.b, piscaPisca);
	}
}
