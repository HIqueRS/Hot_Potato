using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Luzinhas : MonoBehaviour
{
	public Light luz;
	public Image bg;
	public Image image;
	//frame
	public int oque; // 0 - luz
	public int onde; // 0 - cozinha

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void Decreased(float valor)
	{
		luz.intensity -= valor * Time.deltaTime;
		bg.color = new Color(bg.color.r, bg.color.g, bg.color.b, luz.intensity);
		image.fillAmount = luz.intensity;

	
	}
}
