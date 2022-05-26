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
            }
        }
        else if(gameEvent.EventType == GameEvent.ScoreChangedForGod)
        {
            God changedForGod = gameEvent.Arguments[0] as God;
            GodInfoRepeatedItem infoForGod = null;
            //find the info repeated item belonging to this god
            foreach(Transform child in godDescriptionGrid.transform)
            {
                if(child.gameObject.TryGetComponent<GodInfoRepeatedItem>(out GodInfoRepeatedItem info))
                {
                    if(info.Owner.Name == changedForGod.Name)
                    {
                        infoForGod = info;
                        break;
                    }
                }
            }
            infoForGod.Initialize(changedForGod);
        }  
        
    }
 
    public void ToggleGodInformationPanel()
    {
        godDescriptionGrid.SetActive(!godDescriptionGrid.activeSelf);
    }



}
