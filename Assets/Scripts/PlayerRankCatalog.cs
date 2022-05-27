using UnityEngine;

[CreateAssetMenu(fileName = "PlayerRankCatalog", menuName = "ScriptableObjects/Player Information/PlayerRankCatalog", order = 2)]
public class PlayerRankCatalog : ScriptableObject
{   
    public PlayerPositionScriptableObject[] PlayerPositions;    
}

