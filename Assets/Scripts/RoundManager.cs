using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundManager : MonoBehaviour
{

    [SerializeField] private RoundInfoCatalog roundInfoCatalog;
    [SerializeField] private int startFromRound = 0;
    private int currentRound = 0;

    private void OnEnable() {
        GameEventManager.OnGameEvent += HandleGameEvent;
    }  

    private void OnDisable() {
        GameEventManager.OnGameEvent -= HandleGameEvent;
    }

    private void HandleGameEvent(object sender, GameEvent gameEvent)
    {
        
        if(gameEvent.EventType == GameEvent.StartNewShift)
        {
            Debug.Log("Start new shift!");
            StartNextRound();
        }
    }

    private void Start() {
        //send round info to event manager for listeners
        RoundInfoScriptableObject roundInfo = roundInfoCatalog.GetRoundInfo(startFromRound);
        float roundLength = roundInfo.RoundLength;
        GameEventManager.Send(new GameEvent(this, GameEvent.RoundStarted, new object[]{currentRound, roundLength, roundInfo.RoundNumberOfPeopleInQueue, roundInfo.RoundNumberOfOfficialCriteria}));
    }

    public void StartNextRound()
    {
        //this method could be called from some button in game, or this could be handled by an event too?
        currentRound ++;
        RoundInfoScriptableObject roundInfo = roundInfoCatalog.GetRoundInfo(currentRound);
        float roundLength = roundInfo.RoundLength;
        GameEventManager.Send(new GameEvent(this, GameEvent.RoundStarted, new object[]{currentRound, roundLength, roundInfo.RoundNumberOfPeopleInQueue, roundInfo.RoundNumberOfOfficialCriteria}));
    }




}
