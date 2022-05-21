using UnityEngine;

[CreateAssetMenu(fileName = "CauseOfDeath", menuName = "ScriptableObjects/Documents/CauseOfDeathScriptableObject", order = 1)]
public class CauseOfDeathScriptableObject : ScriptableObject
{
    public string Description;
    public Criteria[] FulfilledCriteria;

    public CauseOfDeathDocument GetCauseOfDeathDocument()
    {
        return new CauseOfDeathDocument(Description, FulfilledCriteria);
    }
}