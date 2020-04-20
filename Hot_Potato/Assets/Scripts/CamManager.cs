using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

[CreateAssetMenu(fileName = "CamManagement")]
public class CamManager : ScriptableObject
{
    public int[] camsPriority;


   
    public void SetPriority(int cam)
    {
       
        camsPriority[cam] = 15;
        for (int i = 0; i < camsPriority.Length; i++)
        {
            if(cam != i)
            {
                camsPriority[i] = 10;
            }
        }
    }
}
