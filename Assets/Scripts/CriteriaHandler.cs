using System;
using System.Collections.Generic;

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

