using UnityEngine;
using TMPro;
using System;

public class ScoreKeeper : MonoBehaviour 
{

    [SerializeField] private TextMeshProUGUI scoreText;
    private int playerScore;

    private void OnEnable() {
        GameEventManager.OnGameEvent += HandleGameEvent;
    }

    private void OnDisable() {
        GameEventManager.OnGameEvent -= HandleGameEvent;
    }

    private void HandleGameEvent(object sender, GameEvent gameEvent)
    {
       
        if(gameEvent.EventType == GameEvent.PlayerScoreChanged)
        {
            bool positiveChange = (bool)gameEvent.Arguments[0];
            bool sentToEarth = (bool)gameEvent.Arguments[1];
            if(!sentToEarth)
            {
                int multiplier = positiveChange ? 1 : -1;
                playerScore += multiplier;
            }
            else
            {
                int multiplier = 2;
                playerScore += multiplier;
            }
        }

        if(scoreText != null)
        {
            scoreText.text = String.Format("Score: {0}", playerScore.ToString());
        }
    }
}