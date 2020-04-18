using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SmashTheButton : MonoBehaviour
{

	public Slider hitThatButton;
	public TextMeshProUGUI dale;

	//// Start is called before the first frame update
	//void Start()
	//{

	//}

	// Update is called once per frame
	void Update()
	{
		if (hitThatButton.value < 0)
			hitThatButton.value = 0;

		if (hitThatButton.value >= 0)
		{
			hitThatButton.value -= 0.001f;
		}

		if (hitThatButton.value >= 0.9)
		{
			hitThatButton.value = 1;
			dale.text = "DALE";
		}
	}

	public void BtnSmash()
	{
		hitThatButton.value += 0.1f;
	}
}
