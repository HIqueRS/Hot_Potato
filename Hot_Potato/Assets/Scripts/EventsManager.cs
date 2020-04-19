using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventsManager : MonoBehaviour
{

	private int timerControl;
	private int startTime;

    // Start is called before the first frame update
    void Start()
    {
		startTime = Mathf.RoundToInt(Time.timeSinceLevelLoad);
    }

    // Update is called once per frame
    void Update()
    {
		timerControl = Mathf.RoundToInt(Time.timeSinceLevelLoad - startTime);


	}
}
