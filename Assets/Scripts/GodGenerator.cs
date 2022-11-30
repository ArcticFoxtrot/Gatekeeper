using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Gatekeeper.Data;

public class GodGenerator : MonoBehaviour
{
    [Inject]
    IGodDataProvider godDataProvider;
    //[SerializeField] private CriteriaCreator criteriaCreator;
    [SerializeField] private int maxCriteriaCount;

    private List<God> allGods = new List<God>();

    private void Awake()
    {
        var god = GenerateGod(0);
        var god2 = GenerateGod(1);
        var god3 = GenerateGod(2);
    }
    public God GenerateGod(int index)
    {
        GodData newGodData = godDataProvider.GetGodWithIndex(index);

        God newGod = new God(newGodData.Name, newGodData.Description, newGodData.Image, 0);

        //create list of all criteria assigned to god scriptableobject
        List<ICriterion> allCriteria = new List<ICriterion>();
        foreach (var c in newGodData.CauseOfDeathCriteria)
        {
            CauseOfDeathCriterion cause = new CauseOfDeathCriterion(c);
            allCriteria.Add(cause);
        }

        foreach (var c in newGodData.OriginCriteria)
        {
            OriginCriterion origin = new OriginCriterion(c);
            allCriteria.Add(origin);
        }

        foreach (var c in newGodData.RitualCriteria)
        {
            RitualCriterion ritual = new RitualCriterion(c);
            allCriteria.Add(ritual);
        }

        AgeCriterion ageCriterion = new AgeCriterion(newGodData.AgeCriteriaMin, newGodData.AgeCriteriaMax);
        newGod.AssignCriteria(allCriteria);

        allGods.Add(newGod);
        GameEventManager.Send(new GameEvent(this, GameEvent.NewGodCreated, new object[] { newGod }));
        return newGod;
    }

    public God GetLeastPleasedGod()
    {
        int compareTo = 1000;
        God returnGod = null;
        foreach (var g in allGods)
        {
            if (g.GetScoreWithGod() < compareTo)
            {
                compareTo = g.GetScoreWithGod();
                returnGod = g;
            }
        }

        return returnGod;
    }

    public God GetMostPleasedGod()
    {
        int compareTo = -1000;
        God returnGod = null;
        foreach (var g in allGods)
        {
            if (g.GetScoreWithGod() > compareTo)
            {
                compareTo = g.GetScoreWithGod();
                returnGod = g;
            }
        }

        return returnGod;
    }


}