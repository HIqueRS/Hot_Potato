using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockManager : MonoBehaviour
{
	[Tooltip("colocar valor como -360 dividido pelo tempo que vai percorrer os 360 graus")]
	public float segundosEmGraus = -360 / 60;
	
    // Update is called once per frame
    void Update()
    {
		transform.rotation = Quaternion.Euler(0, 0, Time.time * segundosEmGraus);
    }
}
