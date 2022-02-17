using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    public Text timerText;
    private int timerScore = 0;

    void Start()
    {
        InvokeRepeating("Timer", 1f, 1f);
    }

    void Timer()
    {
        timerScore += 1;
        timerText.text = timerScore + " s";
    }
   
}
