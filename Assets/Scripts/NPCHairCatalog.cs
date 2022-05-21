using UnityEngine;
[CreateAssetMenu(fileName = "NPCHairCatalog", menuName = "ScriptableObjects/NPCVisuals/NPCHairCatalog", order = 1)]
public class NPCHairCatalog : ScriptableObject
{
    public Sprite[] AllHairs;

    public Sprite GetRandom()
    {
        int randomInt = Random.Range(0, AllHairs.Length);
        return AllHairs[randomInt];
    }
}