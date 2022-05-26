using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundInformationHandler : MonoBehaviour
{
    [SerializeField] private GameObject roundEndInfoPanel;

    private void OnEnable() {
    GameEventManager.OnGameEvent += HandleGameEvent;
    }

    private void OnDisable() {
    GameEventManager.OnGameEvent -= HandleGameEvent;
    }

    private void HandleGameEvent(object sender, GameEvent gameEvent)
    {
        if(gameEvent.EventType == GameEvent.EndOfTime)
        {
            roundEndInfoPanel.SetActive(true);
        }
    }

    public void OnStartNewShift()
    {
        GameEventManager.Send(new GameEvent(this, GameEvent.StartNewShift));
        roundEndInfoPanel.SetActive(false);
    }

}
