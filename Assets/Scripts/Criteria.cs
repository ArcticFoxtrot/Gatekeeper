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

public enum Name
{
    Topi,
    Antti
}

public enum Ritual
{
    BloodSacrifice,
    FoodSacrifice,
    WealthSacrifice,
    CoveredInHolyOil,
    Embalmed,
    AteTheHolySpam,
    None
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

    private Name name;

    public NameCriterion(Name matchingName)
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
    public CauseOfDeath Cause;

    public CauseOfDeathCriterion(CauseOfDeath cause)
    {
        this.Cause = cause;
    }

    public bool CheckForMatches(NPC npc)
    {
        if(npc.CauseOfDeath.DoesFulfillCriteria(Cause))
        {
            return true;
        }

        else return false;
    }
}

public class OriginCriterion : ICriterion
{
    public Origin Origin;

    public OriginCriterion(Origin origin)
    {
        this.Origin = origin;
    }

    public bool CheckForMatches(NPC npc)
    {
        if(npc.BasicInformation.Origin == Origin)
        {
            return true;
        }

        return false;
    }
}

public class RitualCriterion : ICriterion
{
    public Ritual Ritual;

    public RitualCriterion(Ritual ritual)
    {
        this.Ritual = ritual;
    }

    public bool CheckForMatches(NPC npc)
    {
        if(npc.Ritual.DoesFulfillCriteria(Ritual))
        {
            return true;
        }
        return false;
    }
}


