using System;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    private GameObject currentNPC;

    [SerializeField] private NPCGenerator generator;
    [SerializeField] private CriteriaHandler criteriaHandler;

    private void Initialize()
    {
        GameObject firstNPC = generator.GenerateNPC();
        criteriaHandler.Initialize();
        currentNPC = firstNPC;
        currentNPC.GetComponent<NPC>().MoveToWindow();
    }

    private void OnEnable() {
        GameEventManager.OnGameEvent += HandleGameEvent;
    }

    private void OnDisable() {
        GameEventManager.OnGameEvent += HandleGameEvent;
    }

    private void SwapToNewNPC()
    {
        currentNPC = generator.GenerateNPC();
        if(currentNPC != null && currentNPC.TryGetComponent<NPC>(out NPC npc))
        {
            npc.MoveToWindow();
        }
        else
        {
            //inform that round ended
            GameEventManager.Send(new GameEvent(this, GameEvent.EndOfTime));
        }
    }

    private void HandleGameEvent(object sender, GameEvent gameEvent)
    {
        if(gameEvent.EventType == GameEvent.NPCReachedDestination)
        {
            if(gameEvent.Sender is NPC npc)
            {
                Destroy(npc.gameObject);
            }
        }
        else if(gameEvent.EventType == GameEvent.EntryApproved || gameEvent.EventType == GameEvent.EntryNotApproved || gameEvent.EventType == GameEvent.SentToEarth)
        {
            if(currentNPC.TryGetComponent<NPC>(out NPC npc))
            {
                if(gameEvent.EventType == GameEvent.EntryNotApproved)
                {
                    npc.MoveToHell();
                    criteriaHandler.HandleNPCRejection(npc);
                }
                else if(gameEvent.EventType == GameEvent.EntryApproved)
                {
                    npc.MoveToHeaven();
                    criteriaHandler.HandleNPCAccepted(npc);
                }
                else if(gameEvent.EventType == GameEvent.SentToEarth)
                {
                    npc.MoveToHeaven();
                    criteriaHandler.HandleNPCReturned(npc);
                }
            }

            SwapToNewNPC();
        }
        else if(gameEvent.EventType == GameEvent.EndOfTime)
        {
            //clear current NPC
            GameObject.Destroy(currentNPC);
        }
         if(gameEvent.EventType == GameEvent.RoundStarted)
        {
            if(gameEvent.Arguments[2] is int maxNumber)
            {
                generator.SetRoundMaximum(maxNumber);
                Initialize();
            }
        }
    }


}