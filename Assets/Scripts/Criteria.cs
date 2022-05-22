using System;
using System.Collections.Generic;
using UnityEngine;

public enum CauseOfDeath
{
    KilledByAnimal,
    RitualSacrifice,
    NaturalCauses,
    None
}

public enum Origin
{
    Juva,
    Leppävirta,
    NewYork,
    London,
    Rome,
    Tokyo,
    Adelaide,
    Reading,
    Yukon,
    Miami,
    Birmingham,
    None
}

public class CriteriaCreator
{
    private int[] ageThresholds = new int[]{20, 30, 40, 50, 60, 70}; //maybe not the best to hardcode them here
    private NPCBasicInformationSets basicInformationSets;
    private List<OriginCriterion> originCriteria = new List<OriginCriterion>();
    private List<CauseOfDeathCriterion> causeOfDeathCriteria = new List<CauseOfDeathCriterion>();
    private List<NameCriterion> nameCriteria = new List<NameCriterion>();
    private List<ICriterion> allCriteria = new List<ICriterion>();

    public CriteriaCreator(NPCBasicInformationSets basicInfo)
    {
        basicInformationSets = basicInfo;
    }

    public void Initialize()
    {
        //make new OriginCriterias based on Origins enum
        for (int i = 0; i < (int)Origin.None; i++)
        {
            OriginCriterion c = new OriginCriterion((Origin)i);
            originCriteria.Add(c);
        }

        //list causes of death
        for (int i = 0; i < (int)CauseOfDeath.None; i++)
        {
            CauseOfDeathCriterion c = new CauseOfDeathCriterion((CauseOfDeath)i);
            causeOfDeathCriteria.Add(c);
        }

        for (int i = 0; i < basicInformationSets.Names.Length; i++)
        {
            NameCriterion c = new NameCriterion(basicInformationSets.Names[i]);
            nameCriteria.Add(c);
        }

        allCriteria.AddRange(originCriteria);
        allCriteria.AddRange(causeOfDeathCriteria);
        allCriteria.AddRange(nameCriteria);     
    }

    public ICriterion GetRandom()
    {
        if(allCriteria.Count < 1) {return null;}

        int index = UnityEngine.Random.Range(0, allCriteria.Count);
        return allCriteria[index];
    }
}


public interface ICriterion
{
    bool CheckForMatches(NPC npc);
}

public class AgeCriterion : ICriterion
{
    private int maxAge;
    private int minAge;

    public AgeCriterion(int minAgeInclusive, int maxAgeExclusive)
    {
        maxAge = maxAgeExclusive;
        minAge = minAgeInclusive;
    }


    public bool CheckForMatches(NPC npc)
    {
        if(npc.BasicInformation.Age < maxAge && npc.BasicInformation.Age >= minAge)
        {
            return true;
        }

        return false;
    }
}

public class NameCriterion : ICriterion
{

    private string name;

    public NameCriterion(string matchingName)
    {
        name = matchingName;
    }
    public bool CheckForMatches(NPC npc)
    {
        if(npc.BasicInformation.Name == name)
        {
            return true;
        }

        return false;
    }
}

public class CauseOfDeathCriterion : ICriterion
{
    private CauseOfDeath cause;

    public CauseOfDeathCriterion(CauseOfDeath cause)
    {
        this.cause = cause;
    }

    public bool CheckForMatches(NPC npc)
    {
        if(npc.CauseOfDeath.DoesFulfillCriteria(cause))
        {
            return true;
        }

        else return false;
    }
}

public class OriginCriterion : ICriterion
{
    private Origin origin;

    public OriginCriterion(Origin origin)
    {
        this.origin = origin;
    }

    public bool CheckForMatches(NPC npc)
    {
        if(npc.BasicInformation.Origin == origin)
        {
            return true;
        }

        return false;
    }
}


