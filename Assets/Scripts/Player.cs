using System;
using System.Collections.Generic;
using UnityEngine;
public class Player : MonoBehaviour
{
    public int TotalScore;
    public Rank CurrentPosition;
    [SerializeField] private PlayerRankCatalog rankCatalog;

    private void OnEnable() {
        GameEventManager.OnGameEvent += HandleGameEvent;
    }

    private void OnDisable() {
        GameEventManager.OnGameEvent -= HandleGameEvent;
    }

    private void HandleGameEvent(object sender, GameEvent gameEvent)
    {
        if(gameEvent.EventType == GameEvent.PlayerScoreChanged)
        {
            bool positiveChange = (bool)gameEvent.Arguments[0];
            bool sentToEarth = (bool)gameEvent.Arguments[1];
            if(!sentToEarth)
            {
                int multiplier = positiveChange ? 1 : -1;
                TotalScore += multiplier;
            }
            else
            {
                int multiplier = 2;
                TotalScore += multiplier;
            }
        }
  
    }

    public Rank GetCurrentPosition()
    {
        CurrentPosition = rankCatalog.GetRankWithPoints(TotalScore).Rank;
        return CurrentPosition;
    }
}

public enum Rank
{
    Intern,
    JuniorClerk,
    Clerk,
    SeniorClerk,
    LeadClerk,
    ClerkSupreme,
    GateKeeper
}

public class Tool
{
    //TODO not implemented, could be some tools used to investigate the NPCs documents
}

