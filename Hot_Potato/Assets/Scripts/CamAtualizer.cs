using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CamAtualizer : MonoBehaviour
{

    public CinemachineClearShot[] cams;
    public CamManager man;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < cams.Length; i++)
        {
            cams[i].Priority = man.camsPriority[i];
        }
    }
}
