using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gatekeeper.Data;
using Zenject;

public class RoundManager : MonoBehaviour
{

    [Inject] private IRoundDataProvider roundDataProvider;
    [SerializeField] private int startFromRound = 0;
    public int CurrentRound = 0;
    public int maxRoundsToPlay = 10;

    private void OnEnable()
    {
        GameEventManager.OnGameEvent += HandleGameEvent;
    }

    private void OnDisable()
    {
        GameEventManager.OnGameEvent -= HandleGameEvent;
    }

    private void HandleGameEvent(object sender, GameEvent gameEvent)
    {

        if (gameEvent.EventType == GameEvent.StartNewShift)
        {

            StartNextRound();
        }

        if (gameEvent.EventType == GameEvent.EndOfTime)
        {
            if (maxRoundsToPlay <= CurrentRound)
            {
                GameEventManager.Send(new GameEvent(this, GameEvent.GameEnded));
            }
        }
    }

    private void Start()
    {
        //send round info to event manager for listeners
        RoundData roundInfo = roundDataProvider.GetRoundData(startFromRound);
        float roundLength = roundInfo.RoundLength;

        GameEventManager.Send(new GameEvent(this, GameEvent.RoundStarted, new object[] { CurrentRound, roundLength, roundInfo.RoundNumberOfPeopleInQueue, roundInfo.RoundNumberOfOfficialCriteria }));
    }

    public void StartNextRound()
    {
        //this method could be called from some button in game, or this could be handled by an event too?
        CurrentRound++;
        RoundData roundInfo = roundDataProvider.GetRoundData(CurrentRound);

        if (roundInfo != null && maxRoundsToPlay > CurrentRound)
        {
            float roundLength = roundInfo.RoundLength;

            GameEventManager.Send(new GameEvent(this, GameEvent.RoundStarted, new object[] { CurrentRound, roundLength, roundInfo.RoundNumberOfPeopleInQueue, roundInfo.RoundNumberOfOfficialCriteria }));
        }
        else
        {
            GameEventManager.Send(new GameEvent(this, GameEvent.GameEnded));
        }
    }




}
