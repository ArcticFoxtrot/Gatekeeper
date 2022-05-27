using UnityEngine;

[CreateAssetMenu(fileName = "PlayerPosition", menuName = "ScriptableObjects/Player Information/PlayerPosition", order = 1)]
public class PlayerPositionScriptableObject : ScriptableObject
{
    public Rank Rank;
    public int ScoreRequired;
}