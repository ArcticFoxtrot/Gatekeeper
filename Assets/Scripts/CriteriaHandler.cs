using System;
using System.Collections.Generic;
using UnityEngine;

public class CriteriaHandler : MonoBehaviour
{
    
    //manages what criteria is currently accepted
    private HashSet<ICriterion> officialAcceptedCriteria = new HashSet<ICriterion>();
    private Dictionary<ICriterion, HashSet<God>> acceptedCriteriaForGods = new Dictionary<ICriterion, HashSet<God>>();
    private Dictionary<string, int> pointsByGod = new Dictionary<string, int>();

    private void OnEnable() {
        GameEventManager.OnGameEvent += HandleGameEvent;
    }

    private void OnDisable() {
        GameEventManager.OnGameEvent -= HandleGameEvent;
    }

    private void HandleGameEvent(object sender, GameEvent gameEvent)
    {
        if(gameEvent.EventType == GameEvent.NewGodCreated && gameEvent.Arguments[0] is God newGod)
        {
            foreach(var criterion in newGod.PleasingCriteria)
            {
                if(acceptedCriteriaForGods.ContainsKey(criterion))
                {
                    //modify the key to include the god
                    if(acceptedCriteriaForGods.TryGetValue(criterion, out HashSet<God> gods))
                    {
                        gods.Add(newGod);
                    }
                }
                else
                {
                    //add a new dictionary entry with new god as value
                    acceptedCriteriaForGods.TryAdd(criterion, new HashSet<God>(){newGod});
                }
            }
            int randomIndex = UnityEngine.Random.Range(0, newGod.PleasingCriteria.Count);
            pointsByGod.TryAdd(newGod.Name, newGod.GetScoreWithGod());
            AddOfficialCriteria(newGod.PleasingCriteria[randomIndex]);
        }
    }


    public void Initialize()
    {
        //Gets Gods and their criteria for this session start
        
    }

    public void AddOfficialCriteria(ICriterion newCriteria)
    {
        Debug.Log("Added to official criteria: " + newCriteria.ToString());
        officialAcceptedCriteria.Add(newCriteria);
        GameEventManager.Send(new GameEvent(this, GameEvent.OfficialCriteriaAdded, new object[]{officialAcceptedCriteria}));
    }

    public void HandleNPCRejection(NPC npc)
    {
        //rejection reduces the amount of points for gods who would be pleased by some criteria
        //criteria can be related to any information on the NPC
         
        foreach(var criterion in officialAcceptedCriteria)
        {
            if(criterion.CheckForMatches(npc))
            {
                Debug.Log("Handling NPC Rejected, rejected someone with matching criteria " + criterion.ToString());
                GameEventManager.Send(new GameEvent(this, GameEvent.PlayerScoreChanged, new object[]{false, false}));
            }
        }
        foreach(var criterionKey in acceptedCriteriaForGods)
        {
            if(criterionKey.Key.CheckForMatches(npc))
            {
                foreach(var god in acceptedCriteriaForGods[criterionKey.Key])
                {
                    pointsByGod[god.Name]--;
                }

            }
        }
    }

    public void HandleNPCAccepted(NPC npc)
    {
        //accepting increases the amount of points for gods who would be pleased
        //check if the fulfilled criteria are in official criteria -> increase player score
        foreach(var criterion in officialAcceptedCriteria)
        {
            if(criterion.CheckForMatches(npc))
            {
                Debug.Log("Handling NPC Accepted, Accepted someone with matching criteria " + criterion.ToString());
                GameEventManager.Send(new GameEvent(this, GameEvent.PlayerScoreChanged, new object[]{true, false}));
            }
        }
        //increase points by god for those gods whose criteria are fulfilled
        foreach(var criterionKey in acceptedCriteriaForGods)
        {
            if(criterionKey.Key.CheckForMatches(npc))
            {
                foreach(var god in acceptedCriteriaForGods[criterionKey.Key])
                {
                    pointsByGod[god.Name]++;
                }

            }
        }
    }

    public void HandleNPCReturned(NPC npc)
    {
        Debug.Log("Handling NPC Returned");
        foreach(var criterion in officialAcceptedCriteria)
        {
            if(criterion.CheckForMatches(npc))
            {
                GameEventManager.Send(new GameEvent(this, GameEvent.PlayerScoreChanged, new object[]{true, true}));
            }
        }
        //handle increases and decreases of points per god. If fulfilled, increase, if not fulfilling, decrease. --> really need to be careful when sending someone back!
        foreach(var criterionKey in acceptedCriteriaForGods)
        {
            if(criterionKey.Key.CheckForMatches(npc))
            {
                foreach(var god in acceptedCriteriaForGods[criterionKey.Key])
                {
                    pointsByGod[god.Name]++;
                }

            }
            else
            {
                foreach(var god in acceptedCriteriaForGods[criterionKey.Key])
                {
                    pointsByGod[god.Name]--;
                }
            }
        }
    }



}

