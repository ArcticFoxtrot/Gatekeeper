using UnityEngine;

[CreateAssetMenu(fileName = "RoundInfoScriptableObject", menuName = "ScriptableObjects/Round Information/RoundInfoScriptableObject", order = 1)]
public class RoundInfoScriptableObject : ScriptableObject
{
    public int RoundIndex;
    public int RoundLength;
    public string RoundDescription;
}