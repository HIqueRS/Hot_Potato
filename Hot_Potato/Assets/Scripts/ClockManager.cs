using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockManager : MonoBehaviour
{

	public float segundosEmGraus = -360 / 60;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		Debug.Log(Time.time);

		transform.rotation = Quaternion.Euler(0, 0, Time.time * segundosEmGraus);
    }
}
