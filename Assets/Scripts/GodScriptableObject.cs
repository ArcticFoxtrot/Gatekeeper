using UnityEngine;
[CreateAssetMenu(fileName = "GodScriptableObject", menuName = "ScriptableObjects/GodScriptableObject", order = 1)]
public class GodScriptableObject : ScriptableObject
{
    public string Name;
    public Sprite Image;
    public string Description;
    public int MinPointsBeforeGameOver = -100;

    public CauseOfDeath[] CauseOfDeathCriteria;
    public Origin[] OriginCriteria;
    public int AgeCriteriaMin;
    public int AgeCriteriaMax;
    public Name[] NameCriteria;
    public Ritual[] RitualCriteria;
}