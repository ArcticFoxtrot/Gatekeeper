using UnityEngine;
[CreateAssetMenu(fileName = "NPCEyeCatalog", menuName = "ScriptableObjects/NPCVisuals/NPCEyeCatalog", order = 1)]
public class NPCEyeCatalog : ScriptableObject
{
    public Sprite[] AllEyes;

    public Sprite GetRandom()
    {
        int randomInt = Random.Range(0, AllEyes.Length);
        return AllEyes[randomInt];
    }
    
}
