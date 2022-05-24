using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CriteriaInformationHandler : MonoBehaviour
{    
    [SerializeField] private GameObject criterionDescriptionPrefab;
    [SerializeField] private GameObject criteriaDescriptionGrid;

    private void OnEnable() {
        GameEventManager.OnGameEvent += HandleGameEvent;
    }

    private void OnDisable() {
        GameEventManager.OnGameEvent -= HandleGameEvent;
    }

    private void HandleGameEvent(object sender, GameEvent gameEvent)
    {
        if(gameEvent.EventType == GameEvent.OfficialCriteriaAdded)
        {
            //clear old criteria
            foreach(Transform child in criteriaDescriptionGrid.transform)
            {
                GameObject.Destroy(child.gameObject);
            }
            //re-instantiate
            var criteria = gameEvent.Arguments[0] as HashSet<ICriterion>;
            foreach(var c in criteria)
            {
                var description = GameObject.Instantiate(criterionDescriptionPrefab, criteriaDescriptionGrid.transform.position, Quaternion.identity, criteriaDescriptionGrid.transform);
                if(description.TryGetComponent<TextMeshProUGUI>(out TextMeshProUGUI text))
                {
                    text.text = c.GetDescription();
                }
            }
        }
    }

    public void ToggleOfficialCriteria()
    {
        criteriaDescriptionGrid.gameObject.SetActive(!criteriaDescriptionGrid.gameObject.activeSelf);
    }
}