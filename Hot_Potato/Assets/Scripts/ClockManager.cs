using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockManager : MonoBehaviour
{
	[Tooltip("colocar valor como -360 dividido pelo tempo que vai percorrer os 360 graus")]
	public float segundosEmGrausPMin = -360 / 60;
	public float segundosEmGrausPHoras = -360 / 60;
    public GameObject ponteiroMin;
    public GameObject ponteiroHoras;
    public GameManager gamMan;

    private void Start()
    {
        gamMan = Resources.Load<GameManager>("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        if(gamMan.iniciou)
        {
            Min();
            Horas();
        }
       
    }

    void Min()
    {
        ponteiroMin.transform.rotation = Quaternion.Euler(0, 0, Time.time * segundosEmGrausPMin);
    }

    void Horas()
    {
        ponteiroHoras.transform.rotation = Quaternion.Euler(0, 0, Time.time * segundosEmGrausPHoras);
    }
}
