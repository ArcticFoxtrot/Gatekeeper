using UnityEngine;

[CreateAssetMenu(fileName = "RoundInfoCatalog", menuName = "ScriptableObjects/Round Information/RoundInfoCatalog", order = 1)]
public class RoundInfoCatalog : ScriptableObject
{
    [SerializeField] private RoundInfoScriptableObject[] rounds;

    public RoundInfoScriptableObject GetRoundInfo(int roundIndex)
    {
        if(rounds.Length < roundIndex)
        {
            return rounds[0];
        }

        if(roundIndex < 0)
        {
            return rounds[0];
        }

        if(rounds[roundIndex] == null)
        {
            return rounds[0];
        }

        return rounds[roundIndex];
    }
}