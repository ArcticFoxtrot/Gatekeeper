using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundManager : MonoBehaviour
{

    [SerializeField] private RoundInfoCatalog roundInfoCatalog;
    [SerializeField] private int startFromRound = 0;
    private int currentRound = 0;

    private void Start() {
        //send round info to event manager for listeners
        RoundInfoScriptableObject roundInfo = roundInfoCatalog.GetRoundInfo(startFromRound);
        float roundLength = roundInfo.RoundLength;
        GameEventManager.Send(new GameEvent(this, GameEvent.RoundStarted, new object[]{currentRound, roundLength}));
    }


}
