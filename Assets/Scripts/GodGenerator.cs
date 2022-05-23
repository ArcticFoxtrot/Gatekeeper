using System.Collections.Generic;
using UnityEngine;

public class GodGenerator : MonoBehaviour 
{
    [SerializeField] private GodCatalog godCatalog;
    //[SerializeField] private CriteriaCreator criteriaCreator;
    [SerializeField] private int maxCriteriaCount;

    private void Start() {
        var god = GenerateGod(0);
        var god2 = GenerateGod(1);
    }

    public God GenerateGod(int index)
    {
        God newGod = godCatalog.GetGodWithIndex(index);
        GameEventManager.Send(new GameEvent(this, GameEvent.NewGodCreated, new object[]{newGod}));
        return newGod;
    }


}