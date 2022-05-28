using System;
using System.Collections.Generic;
using UnityEngine;

public enum CauseOfDeath
{
    KilledByAnimal,
    RitualSacrifice,
    NaturalCauses,
    DiedInAFire,
    Crucifixion,
    Murder,
    Disease,
    OverEating,
    FellFromHigh,
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
    Tophos,
    Andreas,
    Phobos,
    Pho,
    Myrtle,
    Olive,
    Pune,
    Homer,
    Traccus,
    Wyl,
    Pim,
    Wal,
    Nym,
    Eru

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
    string GetDescription();
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

    public string GetDescription()
    {
        string retVal = String.Format("Age between {0} and {1}", minAge, maxAge);
        return retVal;
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

    public string GetDescription()
    {
        return String.Format("Deceased is called {0}", name.ToString());
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

    public string GetDescription()
    {
        return String.Format("Died by {0}", Cause.ToString());
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

    public string GetDescription()
    {
        return String.Format("From: {0}", Origin);
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

    public string GetDescription()
    {
        return String.Format("Ritual completed: {0}", Ritual.ToString());
    }
}


