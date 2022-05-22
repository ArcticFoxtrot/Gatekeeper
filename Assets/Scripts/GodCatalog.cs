using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "GodCatalog", menuName = "ScriptableObjects/GodCatalog", order = 1)]
public class GodCatalog : ScriptableObject
{
    public GodScriptableObject[] Gods;

    public God GetGodWithIndex(int index)
    {
        GodScriptableObject godScriptableObject = Gods[index];
        God god = new God(godScriptableObject.Name, godScriptableObject.Description, godScriptableObject.Image, 0);

        //create list of all criteria assigned to god scriptableobject
        List<ICriterion> allCriteria = new List<ICriterion>();
        foreach(var c in godScriptableObject.CauseOfDeathCriteria)
        {
            CauseOfDeathCriterion cause = new CauseOfDeathCriterion(c);
            allCriteria.Add(cause);
        }

        foreach(var c in godScriptableObject.OriginCriteria)
        {
            OriginCriterion origin = new OriginCriterion(c);
            allCriteria.Add(origin);
        }

        foreach(var c in godScriptableObject.RitualCriteria)
        {
            RitualCriterion ritual = new RitualCriterion(c);
            allCriteria.Add(ritual);
        }

        AgeCriterion ageCriterion = new AgeCriterion(godScriptableObject.AgeCriteriaMin, godScriptableObject.AgeCriteriaMax);
        god.AssignCriteria(allCriteria);
        return god;
    }

}