using UnityEngine;
[CreateAssetMenu(fileName = "GodCatalog", menuName = "ScriptableObjects/GodCatalog", order = 1)]
public class GodCatalog : ScriptableObject
{
    public string[] GodNames;
    public Sprite[] GodImages;
    public string[] GodDescriptions;

    public God GetRandom()
    {
        int nameIndex = Random.Range(0, GodNames.Length);
        string name = GodNames[nameIndex];
        int imageIndex = Random.Range(0, GodImages.Length);
        Sprite image = GodImages[imageIndex];
        int descIndex = Random.Range(0, GodDescriptions.Length);
        string description = GodDescriptions[descIndex];
        var god = new God(name, description, image, 0);
        return god;
    }
}