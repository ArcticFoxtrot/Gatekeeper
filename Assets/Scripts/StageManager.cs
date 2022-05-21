using System;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    private GameObject currentNPC;
    private GameObject previousNPC;

    [SerializeField] private NPCGenerator generator;
    [SerializeField] private Transform startPosition;

    private void Start() {
        GameObject firstNPC = generator.GenerateNPC(startPosition);
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
        previousNPC = currentNPC;
        currentNPC = generator.GenerateNPC(startPosition);
    }

    private void DestroyPreviousNPC()
    {
        Debug.Log("Destroying NPC");
        GameObject.Destroy(currentNPC);
        currentNPC = generator.GenerateNPC(startPosition);
        currentNPC.GetComponent<NPC>().MoveToWindow();
    }

    private void HandleGameEvent(object sender, GameEvent gameEvent)
    {
        if(gameEvent.EventType == GameEvent.NPCReachedDestination)
        {
            DestroyPreviousNPC();
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