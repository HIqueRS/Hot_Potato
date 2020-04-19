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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        game.intensity[obj] = image.fillAmount = luz.intensity -= 0.1f*Time.deltaTime; 
    }
}
