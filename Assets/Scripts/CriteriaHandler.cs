using System;
using System.Collections.Generic;
using UnityEngine;

public class CriteriaHandler : MonoBehaviour
{

    //manages what criteria is currently accepted
    private HashSet<ICriterion> officialAcceptedCriteria = new HashSet<ICriterion>();
    private Dictionary<ICriterion, HashSet<God>> acceptedCriteriaForGods = new Dictionary<ICriterion, HashSet<God>>();
    //private Dictionary<God, int> pointsByGod = new Dictionary<God, int>();

    private void OnEnable()
    {
        GameEventManager.OnGameEvent += HandleGameEvent;
    }

    private void OnDisable()
    {
        GameEventManager.OnGameEvent -= HandleGameEvent;
    }

    private void HandleGameEvent(object sender, GameEvent gameEvent)
    {
        if (gameEvent.EventType == GameEvent.NewGodCreated && gameEvent.Arguments[0] is God newGod)
        {
            foreach (var criterion in newGod.PleasingCriteria)
            {
                Debug.Log("Trying to add criteria to accepted criteria for gods");
                if (acceptedCriteriaForGods.ContainsKey(criterion))
                {
                    //modify the key to include the god
                    if (acceptedCriteriaForGods.TryGetValue(criterion, out HashSet<God> gods))
                    {
                        gods.Add(newGod);
                    }
                }
                else
                {
                    //add a new dictionary entry with new god as value
                    acceptedCriteriaForGods.TryAdd(criterion, new HashSet<God>() { newGod });
                }
            }
            int randomIndex = UnityEngine.Random.Range(0, newGod.PleasingCriteria.Count);
        }
        if (gameEvent.EventType == GameEvent.RoundStarted)
        {
            if (gameEvent.Arguments[3] is int numberOfCriteria)
            {
                Debug.Log("Round started and adding official criteria");
                List<ICriterion> criteria = new List<ICriterion>(acceptedCriteriaForGods.Keys);
                officialAcceptedCriteria.Clear();
                if (criteria.Count > 0)
                {
                    Debug.Log("Round started and adding official criteria, there are more than 0 criteria available, number of criteria wanted is " + numberOfCriteria);
                    while (officialAcceptedCriteria.Count < numberOfCriteria)
                    {
                        //for each god get a random criteria, but no duplicates
                        int randomIndex = UnityEngine.Random.Range(0, acceptedCriteriaForGods.Count);
                        //if criterion is already in the set of accepted criteria, try again
                        var criterioncandidate = criteria[randomIndex];
                        bool canAdd = true;
                        foreach (var officialCriteria in officialAcceptedCriteria)
                        {
                            if (officialCriteria.GetDescription() == criterioncandidate.GetDescription())
                            {
                                canAdd = false;
                            }
                        }
                        if (canAdd)
                        {
                            officialAcceptedCriteria.Add(criteria[randomIndex]);
                        }

                    }

                }
                else
                {
                    Debug.LogWarning("Dictionary of criteria was empty!");
                }

                GameEventManager.Send(new GameEvent(this, GameEvent.OfficialCriteriaAdded, new object[] { officialAcceptedCriteria }));
            }


        }


    }


    public void Initialize()
    {
        //Gets Gods and their criteria for this session start

    }

    public void AddOfficialCriteria(ICriterion newCriteria)
    {
        officialAcceptedCriteria.Add(newCriteria);
        GameEventManager.Send(new GameEvent(this, GameEvent.OfficialCriteriaAdded, new object[] { officialAcceptedCriteria }));
    }

    public void HandleNPCRejection(NPC npc)
    {
        //rejection reduces the amount of points for gods who would be pleased by some criteria
        //criteria can be related to any information on the NPC

        foreach (var criterion in officialAcceptedCriteria)
        {
            if (criterion.CheckForMatches(npc))
            {
                GameEventManager.Send(new GameEvent(this, GameEvent.PlayerScoreChanged, new object[] { false, false }));
            }
        }
        foreach (var criterionKey in acceptedCriteriaForGods)
        {
            if (criterionKey.Key.CheckForMatches(npc))
            {
                foreach (var god in acceptedCriteriaForGods[criterionKey.Key])
                {
                    god.AddToScoreWithGod(-1);
                }

            }
        }
    }

    public void HandleNPCAccepted(NPC npc)
    {
        //accepting increases the amount of points for gods who would be pleased
        //check if the fulfilled criteria are in official criteria -> increase player score
        foreach (var criterion in officialAcceptedCriteria)
        {
            if (criterion.CheckForMatches(npc))
            {
                GameEventManager.Send(new GameEvent(this, GameEvent.PlayerScoreChanged, new object[] { true, false }));
            }
        }
        //increase points by god for those gods whose criteria are fulfilled
        foreach (var criterionKey in acceptedCriteriaForGods)
        {
            if (criterionKey.Key.CheckForMatches(npc))
            {
                foreach (var god in acceptedCriteriaForGods[criterionKey.Key])
                {
                    god.AddToScoreWithGod(1); ;
                }
            }
        }
    }

    public void HandleNPCReturned(NPC npc)
    {
        foreach (var criterion in officialAcceptedCriteria)
        {
            if (criterion.CheckForMatches(npc))
            {
                GameEventManager.Send(new GameEvent(this, GameEvent.PlayerScoreChanged, new object[] { true, true }));
            }
        }
        //handle increases and decreases of points per god. If fulfilled, increase, if not fulfilling, decrease. --> really need to be careful when sending someone back!
        foreach (var criterionKey in acceptedCriteriaForGods)
        {
            if (criterionKey.Key.CheckForMatches(npc))
            {
                foreach (var god in acceptedCriteriaForGods[criterionKey.Key])
                {
                    god.AddToScoreWithGod(1);
                }

            }
            else
            {
                foreach (var god in acceptedCriteriaForGods[criterionKey.Key])
                {
                    god.AddToScoreWithGod(-1);
                }

            }
        }
    }



}

