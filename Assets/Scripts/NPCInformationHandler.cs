using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class NPCInformationHandler : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI basicInfoText;
    [SerializeField] private TextMeshProUGUI causeOfDeath;


    private void OnEnable() {
        GameEventManager.OnGameEvent += HandleGameEvent;
    }

    private void OnDisable() {
        GameEventManager.OnGameEvent -= HandleGameEvent;
    }

    private void HandleGameEvent(object sender, GameEvent gameEvent)
    {
        if(gameEvent.EventType == GameEvent.NextNPCReady)
        {
            GameObject character = gameEvent.Arguments[0] as GameObject;
            
            if(character.TryGetComponent(out NPC npc))
            {
                string basicInfo = String.Format("Name: {0} \nAge : {1} \nBirth: {2} \nFrom: {3}", npc.BasicInformation.Name, npc.BasicInformation.Age, npc.BasicInformation.BirthYear, npc.BasicInformation.Origin);
                basicInfoText.text = basicInfo;
                causeOfDeath.text = String.Format("Cause of Death: " + npc.CauseOfDeath.ReadDocument());
            }
            
        }

        if(gameEvent.EventType == GameEvent.EntryApproved || gameEvent.EventType == GameEvent.EntryNotApproved || gameEvent.EventType == GameEvent.SentToEarth)
        {
            basicInfoText.text = string.Empty;
            causeOfDeath.text = string.Empty;
        }
    }

}