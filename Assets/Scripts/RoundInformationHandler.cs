using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RoundInformationHandler : MonoBehaviour
{
    [SerializeField] private GameObject roundEndInfoPanel;
    [SerializeField] private TextMeshProUGUI gameOverText;
    [SerializeField] private TextMeshProUGUI processedNPCsText;
    [SerializeField] private TextMeshProUGUI criteriaFollowedText;
    [SerializeField] private TextMeshProUGUI leastPleasedGodText;
    [SerializeField] private TextMeshProUGUI mostPleasedGodText;
    [SerializeField] private TextMeshProUGUI playerRankText;
    [SerializeField] private Sprite gameOverSprite;
    [SerializeField] private GameObject gameOverButton;
    [SerializeField] private GameObject nextShiftButton;
    [SerializeField] private RoundManager roundManager;

    private int processedNPCs = 0;
    private int timesOfficialCriteriaFollowed = 0;
    private void OnEnable() {
    GameEventManager.OnGameEvent += HandleGameEvent;
    }

    private void OnDisable() {
    GameEventManager.OnGameEvent -= HandleGameEvent;
    }

    private void HandleGameEvent(object sender, GameEvent gameEvent)
    {
        if(gameEvent.EventType == GameEvent.EndOfTime || gameEvent.EventType == GameEvent.GameEnded)
        {
            if(gameEvent.EventType == GameEvent.GameEnded || roundManager.maxRoundsToPlay <= roundManager.CurrentRound + 1)
            {
                roundEndInfoPanel.GetComponent<Image>().sprite = gameOverSprite;
                gameOverText.text = "The game has ended\nYour performance in your last shift: ";
                gameOverButton.SetActive(true);
                nextShiftButton.SetActive(false);
            }
            roundEndInfoPanel.SetActive(true);
            GatherRoundEndInformation();
        }
        if(gameEvent.EventType == GameEvent.EntryApproved || gameEvent.EventType == GameEvent.SentToEarth || gameEvent.EventType == GameEvent.EntryNotApproved)
        {
            processedNPCs++;
        }
        if(gameEvent.EventType == GameEvent.PlayerScoreChanged)
        {
            if(gameEvent.Arguments[0] is bool officialCriteriaFollowed)
            {
                if(officialCriteriaFollowed)
                {
                    timesOfficialCriteriaFollowed++;
                }
            }
        }
    }

    private void GatherRoundEndInformation()
    {
        //Get score from Player
        var player = GameObject.FindObjectOfType<Player>();
        if(player != null && playerRankText != null)
        {
            playerRankText.text = String.Format("Your current position in the Organization is: {0}", player.GetCurrentPosition().ToString());
        }
        if(processedNPCsText != null)
        {
            processedNPCsText.text = String.Format("Processed {0} people", processedNPCs.ToString());
        }
        if(criteriaFollowedText != null)
        {
            criteriaFollowedText.text = String.Format("Official criteria followed {0} times", timesOfficialCriteriaFollowed.ToString());
        }

        var godGenerator = GameObject.FindObjectOfType<GodGenerator>();
        if(godGenerator != null && leastPleasedGodText != null)
        {
            leastPleasedGodText.text = String.Format("Your actions have pleased {0} the least, your score with them is {1}", godGenerator.GetLeastPleasedGod().Name, godGenerator.GetLeastPleasedGod().GetScoreWithGod());
        }
        if(godGenerator != null && mostPleasedGodText != null)
        {
            mostPleasedGodText.text = String.Format("{0} is most pleased with you, your score with them is {1}", godGenerator.GetMostPleasedGod().Name, godGenerator.GetMostPleasedGod().GetScoreWithGod());
        }

    }

    public void OnStartNewShift()
    {
        GameEventManager.Send(new GameEvent(this, GameEvent.StartNewShift));
        processedNPCs = 0;
        timesOfficialCriteriaFollowed = 0;
        roundEndInfoPanel.SetActive(false);
    }

    public void OnRestartGame()
    {
        SceneManager.LoadScene(0);
    }


}

