using UnityEngine;
[CreateAssetMenu(fileName = "NPCEarCatalog", menuName = "ScriptableObjects/NPCVisuals/NPCEarCatalog", order = 1)]
public class NPCEarCatalog : ScriptableObject
{
    public Sprite[] AllEars;

    public Sprite GetRandom()
    {
        int randomInt = Random.Range(0, AllEars.Length);
        return AllEars[randomInt];
    }
}
