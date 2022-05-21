using UnityEngine;
[CreateAssetMenu(fileName = "NPCEyeBrowCatalog", menuName = "ScriptableObjects/NPCVisuals/NPCEyeBrowCatalog", order = 1)]
public class NPCEyeBrowCatalog : ScriptableObject
{
    public Sprite[] AllEyeBrows;

    public Sprite GetRandom()
    {
        int randomInt = Random.Range(0, AllEyeBrows.Length);
        return AllEyeBrows[randomInt];
    }
}

