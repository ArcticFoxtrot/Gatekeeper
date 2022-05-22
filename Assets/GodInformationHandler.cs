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
            //set text
            if(newInformation.TryGetComponent<TextMeshProUGUI>(out TextMeshProUGUI text) && sender is God god)
            {
                text.text = god.GetGodDescription();
            }
        }
    }

    public void ToggleGodInformationPanel()
    {
        godDescriptionGrid.SetActive(!godDescriptionGrid.activeSelf);
    }



}
