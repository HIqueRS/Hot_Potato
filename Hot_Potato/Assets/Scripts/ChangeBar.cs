using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ChangeBar : MonoBehaviour
{

    public Image image;
    public GameManager game;
    public int obj;
    public Light luz;
    private float maxIntensity;
    // Start is called before the first frame update
    void Start()
    {
        maxIntensity = luz.intensity;
    }

    // Update is called once per frame
    void Update()
    {


		MudaLuzEBarra(obj);
    }

	void MudaLuzEBarra(int num)
	{
        luz.intensity -= 0.1f * Time.deltaTime;
        game.intensity[num] = image.fillAmount = luz.intensity/ maxIntensity;
	}
}
