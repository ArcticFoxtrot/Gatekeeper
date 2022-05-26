using UnityEngine;
using TMPro;
public class GodInfoRepeatedItem : MonoBehaviour 
{
    
    //use these to show god info, also in grid systems with multiplied items
    [SerializeField] private TextMeshProUGUI godDescriptionText;
    [SerializeField] private TextMeshProUGUI godScoreText;
    
    public God Owner;

    public void Initialize(God god)
    {
        Owner = god;
        godDescriptionText.text = god.GetGodDescription();
        godScoreText.text = god.GetScoreWithGod().ToString();
    }
}
