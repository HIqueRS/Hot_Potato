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
	public TextMeshProUGUI mensagem;


    // Start is called before the first frame update
    void Start()
    {
		aumentando = true;

		minimo = Random.Range(0, 0.8f);
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
				mensagem.text = "AE CARALEO";
			}
			else
			{
				mensagem.text = "ohno";
			}
		}
    }

	void VaieVolta()
	{
		if (aumentando)
		{
			ligarCoisinhas.value += Time.deltaTime * (0.5f);
		}
		else if (!aumentando)
		{
			ligarCoisinhas.value -= Time.deltaTime * (0.5f);
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
