using System.Collections.Generic;
using UnityEngine;

public class GodGenerator : MonoBehaviour 
{
    [SerializeField] private GodCatalog godCatalog;
    //[SerializeField] private CriteriaCreator criteriaCreator;
    [SerializeField] private int maxCriteriaCount;

    public God GenerateGod(int index)
    {
        God newGod = godCatalog.GetGodWithIndex(index);
        return newGod;
    }


}