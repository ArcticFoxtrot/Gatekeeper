public static class Extensions
{
    public static string CauseOfDeathConverter(CauseOfDeath cause)
    {
        string retVal = "";
        switch(cause)
        {
            case CauseOfDeath.KilledByAnimal:
                retVal = "Killed by an animal";
                break;
            case CauseOfDeath.RitualSacrifice:
                retVal = "Sacrificed in ritual";
                break;
            case CauseOfDeath.NaturalCauses:
                retVal = "Died of natural causes";
                break;
            case CauseOfDeath.DiedInAFire:
                retVal = "Died in a fire";
                break;
            case CauseOfDeath.Crucifixion:
                retVal = "Was crucified";
                break;
            case CauseOfDeath.Murder:
                retVal = "Was murdered";
                break;
            case CauseOfDeath.Disease:
                retVal = "Died of sickness";
                break;
            case CauseOfDeath.OverEating:
                retVal = "Died of gluttony";
                break;
            case CauseOfDeath.FellFromHigh:
                retVal = "Fell from a high place";
                break;

        }

        return retVal;
    }

    public static string RitualConverter(Ritual ritual)
    {
        string retVal = "";
        switch(ritual)
        {
            case Ritual.BloodSacrifice:
                retVal = "Gave blood sacrifice";
                break;
            case Ritual.FoodSacrifice:
                retVal = "Sacrificed food to the gods";
                break;
            case Ritual.CoveredInHolyOil:
                retVal = "Oiled according to the five spells";
                break;
            case Ritual.Embalmed:
                retVal = "Was embalmed";
                break;
            case Ritual.AteTheHolySpam:
                retVal = "Ingested the Holy Spam";
                break;
            
            

        }

        return retVal;
    }
}
