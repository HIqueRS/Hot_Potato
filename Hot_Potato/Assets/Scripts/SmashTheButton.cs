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
	private GameManager gamMan;

	private void Start()
	{
		slider = GameObject.FindGameObjectWithTag("GameController");
		gamMan = Resources.Load<GameManager>("GameManager");
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
			hitThatButton.value = 0;

			slider.GetComponent<SliderManager>().AcertouBotao();
			gamMan.inMinigame = false;
			gamMan.luzCozinha = false;
			gamMan.luzSala = false;
			gamMan.fogoCozinha = false;
			gamMan.fogoSala = false;
		}
	}

	public void BtnSmash()
	{
		hitThatButton.value += 0.1f;
	}
}
