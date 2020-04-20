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

    public void Comecar(bool comecou)
    {
        jogoComecou = comecou;
    }
}
