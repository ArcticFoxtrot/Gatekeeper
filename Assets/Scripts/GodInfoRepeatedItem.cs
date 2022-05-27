using UnityEngine;
using TMPro;
using System;

public class GodInfoRepeatedItem : MonoBehaviour 
{
    
    //use these to show god info, also in grid systems with multiplied items
    [SerializeField] private TextMeshProUGUI godDescriptionText;
    [SerializeField] private TextMeshProUGUI godScoreText;
    
    public God Owner;

    public void Initialize(God god)
    {
        Owner = god;
        Debug.Log("Bugs: Owner name is " + Owner.Name);
        godDescriptionText.text = god.GetGodDescription();
        godScoreText.text = god.GetScoreWithGod().ToString();
    }

}
