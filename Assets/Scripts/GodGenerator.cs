using System.Collections.Generic;
using UnityEngine;

public class GodGenerator : MonoBehaviour 
{
    [SerializeField] private GodCatalog godCatalog;
    [SerializeField] private CriteriaCreator criteriaCreator;
    [SerializeField] private int maxCriteriaCount;

    public void Initialize()
    {
        criteriaCreator.Initialize();
    }
    
    public God GenerateGod()
    {
        God newGod = godCatalog.GetRandom();
        List<ICriterion> criteria = new List<ICriterion>();
        for (int i = 0; i < maxCriteriaCount; i++)
        {
            criteria.Add(criteriaCreator.GetRandom());
        }
        newGod.AssignCriteria(criteria);
        return newGod;
    }


}