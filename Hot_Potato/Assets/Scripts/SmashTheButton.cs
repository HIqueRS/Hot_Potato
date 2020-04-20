using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SmashTheButton : MonoBehaviour
{

	public Slider hitThatButton;
	public TextMeshProUGUI dale;

	private GameObject slider;

	private void Start()
	{
		slider = GameObject.FindGameObjectWithTag("GameController");
	}

	// Update is called once per frame
	void Update()
	{
		if (hitThatButton.value < 0)
		{
			hitThatButton.value = 0;
		}

		if (hitThatButton.value >= 0)
		{
			hitThatButton.value -= 0.001f;
		}

		if (hitThatButton.value >= 0.9)
		{
			hitThatButton.value = 1;

			slider.GetComponent<SliderManager>().AcertouBotao();
		}
	}

	public void BtnSmash()
	{
		hitThatButton.value += 0.1f;
	}
}
