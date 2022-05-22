using System;
using System.Collections.Generic;
using UnityEngine;

public class CriteriaHandler
{

    public CriteriaHandler()
    {
        //get gods from scriptableObject
    }

    //manages what criteria is currently accepted
    private HashSet<ICriterion> officialAcceptedCriteria = new HashSet<ICriterion>();
    private Dictionary<ICriterion, God[]> acceptedCriteriaByGod = new Dictionary<ICriterion, God[]>();
    private Dictionary<int, God> pointsByGod = new Dictionary<int, God>();

    public void Initialize()
    {
        //Gets Gods and their criteria for this session

    }

    public void AddOfficialCriteria(God[] pleasesGods, ICriterion newCriteria)
    {
        officialAcceptedCriteria.Add(newCriteria);
    }

    public void HandleNPCRejection(NPC npc)
    {
        //rejection reduces the amount of points for gods who would be pleased by some criteria
        //criteria can be related to any information on the NPC

    }

    public void HandleNPCAccepted(NPC npc)
    {
        //accepting increases the amount of points for gods who would be pleased

    }

    public void HandleNPCReturned(NPC npc)
    {

    }



}

public class God
{
    public string Name;
    public string Description;
    private Sprite image;

    private int scoreWithGod;

    public God(string name, string description, Sprite image, int startingScore)
    {
        this.Name = name;
        this.Description = description;
        this.image = image;
        this.scoreWithGod = startingScore;
    }

    public List<ICriterion> PleasingCriteria;

    //god only knows what criteria pleases it
    //list<Criteria> pleasingCriteria

    //method that checks if handled NPC fulfills any criteria
    public void CheckCriteria(NPC npc, int multiplier)
    {
        foreach(var c in PleasingCriteria)
        {
            if(c.CheckForMatches(npc))
            {
                scoreWithGod += multiplier;
            }
        }
    }

    public void AssignCriteria(List<ICriterion> criteria)
    {
        PleasingCriteria = criteria;
    }
}

