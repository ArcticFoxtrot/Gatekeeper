using UnityEngine;

[CreateAssetMenu(fileName = "CauseOfDeath", menuName = "ScriptableObjects/CauseOfDeathScriptableObject", order = 1)]
public class CauseOfDeathScriptableObject : ScriptableObject
{
    public string Description;
    public Criteria[] FulfilledCriteria;
}