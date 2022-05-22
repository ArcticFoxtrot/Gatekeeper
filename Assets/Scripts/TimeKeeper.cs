using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimeKeeper : MonoBehaviour
{
    [Header("Time limit for the round (seconds)")]
    public float TimeLeft = 30.0f;
    public bool TimerOn = true;

    public TMP_Text timerText;
    

public void Awake()
{
    ResumeTime();
}

public void Update()
{
    if(TimerOn){
        if(TimeLeft > 0)
        {
            TimeLeft -= Time.deltaTime;
            UpdateTimer(TimeLeft);
        }
        else
        {
            Debug.Log("Ime is up!");
            TimeLeft = 0;
            StopTime();
            GameEventManager.Send(new GameEvent(this, GameEvent.EndOfTime));
        }
    }
}

public void StopTime()
{
    if(TimerOn)
    {
      TimerOn = false;  
    }
    
}

public void ResumeTime()
{
    if(!TimerOn)
    {
        TimerOn = true;
    }  
}

void UpdateTimer(float currentTime) //Sain tämän pätkän suoraan youtubesta
{
    currentTime += 1;

    float minutes = Mathf.FloorToInt(currentTime / 60);
    float seconds = Mathf.FloorToInt(currentTime % 60);

    timerText.text = string.Format("{0:00} : {1:00}", minutes, seconds); 
}

public float GetRemainingTime()
{
    return TimeLeft;
}
}