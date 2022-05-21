using UnityEngine;
[CreateAssetMenu(fileName = "NPCCauseOfDeathCatalog", menuName = "ScriptableObjects/Documents/NPCCauseOfDeathCatalog", order = 1)]
public class NPCCauseOfDeathCatalog : ScriptableObject
{
    public CauseOfDeathScriptableObject[] CausesOfDeath;

    public CauseOfDeathScriptableObject GetRandom()
    {
        int randomInt = Random.Range(0, CausesOfDeath.Length);
        return CausesOfDeath[randomInt];
    }
}
