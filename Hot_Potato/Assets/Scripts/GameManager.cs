using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameManager")]
public class GameManager : ScriptableObject
{
    public float[] intensityLuz;
	public float[] intensityFogo;
	public bool iniciou;//trocar pra tutorial

    public bool jogoComecou;

    public bool luzCozinha;
    public bool luzSala;
    public bool fogoSala;
    public bool fogoCozinha;

	public bool inMinigame;

    public void Comecar(bool comecou)
    {
        jogoComecou = comecou;
    }
}
