using UnityEngine;
[CreateAssetMenu(fileName = "NPCMouthCatalog", menuName = "ScriptableObjects/NPCVisuals/NPCMouthCatalog", order = 1)]
public class NPCMouthCatalog : ScriptableObject
{
    public Sprite[] AllMouths;

    public Sprite GetRandom()
    {
        int randomInt = Random.Range(0, AllMouths.Length);
        return AllMouths[randomInt];
    }
}
