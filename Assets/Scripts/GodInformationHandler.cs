using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class GodInformationHandler : MonoBehaviour
{
    [SerializeField] private GameObject godDescriptionPrefab;
    [SerializeField] private GameObject godDescriptionGrid;

    private Dictionary<string, GodInfoRepeatedItem> godInfos = new Dictionary<string, GodInfoRepeatedItem>();

    private void OnEnable() {
        GameEventManager.OnGameEvent += HandleGameEvent;
    }

    private void OnDisable() {
        GameEventManager.OnGameEvent += HandleGameEvent;
    }

    private void HandleGameEvent(object sender, GameEvent gameEvent)
    {
        if(gameEvent.EventType == GameEvent.NewGodCreated)
        {
            var newInformation = GameObject.Instantiate(godDescriptionPrefab, godDescriptionGrid.transform.position, Quaternion.identity, godDescriptionGrid.transform);
            //initialize prefab texts
            if(newInformation.TryGetComponent<GodInfoRepeatedItem>(out GodInfoRepeatedItem info) && gameEvent.Arguments[0] is God god)
            {
                info.Initialize(god);
                godInfos.TryAdd(god.Name, info);
            }
        }
        if(gameEvent.EventType == GameEvent.ScoreChangedForGod)
        {
            if(gameEvent.Arguments[0] is God god)
            {
                //get value from dict
                GodInfoRepeatedItem item = godInfos[god.Name];
                item.Initialize(god);
            }
            
        }
    }
 
    public void ToggleGodInformationPanel()
    {
        godDescriptionGrid.SetActive(!godDescriptionGrid.activeSelf);
    }



}
