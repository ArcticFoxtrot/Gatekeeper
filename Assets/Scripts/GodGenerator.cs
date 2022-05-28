using System;
using System.Collections.Generic;
using UnityEngine;

public class GodGenerator : MonoBehaviour 
{
    [SerializeField] private GodCatalog godCatalog;
    //[SerializeField] private CriteriaCreator criteriaCreator;
    [SerializeField] private int maxCriteriaCount;
    
    private List<God> allGods = new List<God>();

    private void Awake() {
        var god = GenerateGod(0);
        var god2 = GenerateGod(1);
        var god3 = GenerateGod(2);
    }


    public God GenerateGod(int index)
    {
        God newGod = godCatalog.GetGodWithIndex(index);
        allGods.Add(newGod);
        GameEventManager.Send(new GameEvent(this, GameEvent.NewGodCreated, new object[]{newGod}));
        return newGod;
    }

    public God GetLeastPleasedGod()
    {
        int compareTo = 1000;
        God returnGod = null;
        foreach(var g in allGods)
        {
            if(g.GetScoreWithGod() < compareTo)
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
        foreach(var g in allGods)
        {
            if(g.GetScoreWithGod() > compareTo)
            {
                compareTo = g.GetScoreWithGod();
                returnGod = g;
            }
        }

        return returnGod;
    }


}