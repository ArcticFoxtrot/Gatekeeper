using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateInformationHandler : MonoBehaviour
{
    [SerializeField] private GameObject GameOverPanel;

    private void OnEnable() {
        GameEventManager.OnGameEvent += HandleGameEvent;
    }

    private void OnDisable()
    {
        GameEventManager.OnGameEvent -= HandleGameEvent;
    }

    private void HandleGameEvent(object sender, GameEvent gameEvent)
    {
        if(gameEvent.EventType == GameEvent.GameEnded)
        {
            GameOverPanel.SetActive(true);
        }
    }

    public void OnRestart()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }
}
