using UnityEngine;

[CreateAssetMenu(fileName = "RoundInfoCatalog", menuName = "ScriptableObjects/Round Information/RoundInfoCatalog", order = 1)]
public class RoundInfoCatalog : ScriptableObject
{
    public RoundInfoScriptableObject[] rounds;

    private int currentRoundInfo = -1;

    public RoundInfoScriptableObject GetNextRound()
    {
        currentRoundInfo++;
        return rounds[currentRoundInfo];
    }
}