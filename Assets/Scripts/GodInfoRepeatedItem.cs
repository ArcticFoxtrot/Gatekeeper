using UnityEngine;
using TMPro;
using System;

public class GodInfoRepeatedItem : MonoBehaviour 
{
    
    //use these to show god info, also in grid systems with multiplied items
    [SerializeField] private TextMeshProUGUI godDescriptionText;
    [SerializeField] private TextMeshProUGUI godScoreText;
    [SerializeField] private TextMeshProUGUI godCriteriaText;
    
    public God Owner;

    public void Initialize(God god)
    {
        Owner = god;
        godDescriptionText.text = god.GetGodDescription();
        godScoreText.text = String.Format("Current standing: {0}", god.GetScoreWithGod().ToString());
        string criteriaString = "";
        foreach(var c in god.PleasingCriteria)
        {
            if(criteriaString == "")
            {
                criteriaString = c.GetDescription().ToString();
                continue;
            }
            criteriaString = String.Concat(criteriaString, ", ", c.GetDescription().ToString());
        }
        godCriteriaText.text = String.Format("Pleased by: {0}", criteriaString);
    }

}
