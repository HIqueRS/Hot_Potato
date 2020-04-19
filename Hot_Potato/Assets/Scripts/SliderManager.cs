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


    // Start is called before the first frame update
    void Start()
    {
		aumentando = true;

		minimo = Random.Range(0.2f, 0.6f);
		maximo = minimo + (tamanhoSlider / 1000);

		posAreaCerta = minimo * tamanhoSlider;

		areaCerta.rectTransform.Translate(new Vector3(posAreaCerta, 0, 0));
	}

	// Update is called once per frame
	void Update()
	{
		VaieVolta();
		if (Input.GetMouseButtonDown(0))
		{
			if (ligarCoisinhas.value >= minimo && ligarCoisinhas.value <= maximo)
			{

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
}
