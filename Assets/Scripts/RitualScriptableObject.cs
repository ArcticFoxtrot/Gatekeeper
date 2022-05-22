using UnityEngine;

[CreateAssetMenu(fileName = "Ritual", menuName = "ScriptableObjects/Documents/RitualScriptableObject", order = 1)]
public class RitualScriptableObject : ScriptableObject
{
    public string Description;
    public Ritual[] FulfilledCriteria;

    public RitualDocument GetRitualDocument()
    {
        return new RitualDocument(Description, FulfilledCriteria);
    }
}