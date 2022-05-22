using System;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    private GameObject currentNPC;

    [SerializeField] private NPCGenerator generator;
    [SerializeField] private Transform startPosition;

    private void Start() {
        GameObject firstNPC = generator.GenerateNPC();

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
                }
                else
                {
                    npc.MoveToHeaven();
                }
            }

            SwapToNewNPC();
        }
    }


}