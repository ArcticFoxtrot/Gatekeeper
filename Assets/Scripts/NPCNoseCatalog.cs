using UnityEngine;
[CreateAssetMenu(fileName = "NPCNoseCatalog", menuName = "ScriptableObjects/NPCVisuals/NPCNoseCatalog", order = 1)]
public class NPCNoseCatalog : ScriptableObject
{
    public Sprite[] AllNoses;

    public Sprite GetRandom()
    {
        int randomInt = Random.Range(0, AllNoses.Length);
        return AllNoses[randomInt];
    }
}
