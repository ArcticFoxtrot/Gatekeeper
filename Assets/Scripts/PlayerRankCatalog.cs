using UnityEngine;
using System.Linq;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "PlayerRankCatalog", menuName = "ScriptableObjects/Player Information/PlayerRankCatalog", order = 2)]
public class PlayerRankCatalog : ScriptableObject
{   
    public PlayerPositionScriptableObject[] PlayerPositions;

    public PlayerPositionScriptableObject GetRankWithPoints(int points)
    {
        List<PlayerPositionScriptableObject> ranks = PlayerPositions.ToList();
        List<PlayerPositionScriptableObject> ranksOrdered = ranks.OrderBy(o => o.ScoreRequired).ToList();
        int returnRank = 0;
        for (int i = ranksOrdered.Count - 1; i >= 0; i--)
        {
            if(ranksOrdered[i].ScoreRequired > points)
            {
                returnRank = i == 0 ? 0 : i - 1;
            }
        }
        
        return PlayerPositions[returnRank];
    }

}

