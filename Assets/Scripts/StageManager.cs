using System;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    private GameObject currentNPC;

    [SerializeField] private NPCGenerator generator;
    private CriteriaHandler criteriaHandler;

    private void Start() {
        GameObject firstNPC = generator.GenerateNPC();
        criteriaHandler = new CriteriaHandler();
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
        Debug.Log("Swapping NPC");
        currentNPC = generator.GenerateNPC();
        if(currentNPC.TryGetComponent<NPC>(out NPC npc))
        {
            npc.MoveToWindow();
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
                    criteriaHandler.HandleNPCRejection(npc);
                }
                else if(gameEvent.EventType == GameEvent.SentToEarth)
                {
                    npc.MoveToHeaven();
                    criteriaHandler.HandleNPCReturned(npc);
                }
            }

            SwapToNewNPC();
        }
    }


}