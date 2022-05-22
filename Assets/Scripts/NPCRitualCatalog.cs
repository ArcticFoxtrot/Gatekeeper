using UnityEngine;
[CreateAssetMenu(fileName = "NPCRitualCatalog", menuName = "ScriptableObjects/Documents/NPCRitualCatalog", order = 1)]
public class NPCRitualCatalog : ScriptableObject
{
    public RitualScriptableObject[] Rituals;

    public RitualScriptableObject GetRandom()
    {
        int randomInt = Random.Range(0, Rituals.Length);
        return Rituals[randomInt];
    }
}
