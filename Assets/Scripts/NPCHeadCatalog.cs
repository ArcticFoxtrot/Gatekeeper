using UnityEngine;
[CreateAssetMenu(fileName = "NPCHeadCatalog", menuName = "ScriptableObjects/NPCVisuals/NPCHeadCatalog", order = 1)]
public class NPCHeadCatalog : ScriptableObject
{
    public NPCHead[] AllHeads;

    public NPCHead GetRandom()
    {
        int randomInt = Random.Range(0, AllHeads.Length);
        return AllHeads[randomInt];
    }
}
