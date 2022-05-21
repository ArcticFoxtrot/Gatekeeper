using System;
using UnityEngine;
[CreateAssetMenu(fileName = "NPCBasicInformationSets", menuName = "ScriptableObjects/Documents/NPCBasicInformationSets", order = 1)]
public class NPCBasicInformationSets : ScriptableObject
{
    public int MinAge;
    public int MaxAge;

    public string[] Names;
    public string[] Origins;

 
    public NPCBasicInformation GetRandomNPCInformation()
    {
        NPCBasicInformation info = new NPCBasicInformation();
        int nameIndex = UnityEngine.Random.Range(0, Names.Length);
        info.Name = Names[nameIndex];
        int originIndex = UnityEngine.Random.Range(0, Origins.Length);
        info.Origin = Origins[originIndex];

        info.Age = UnityEngine.Random.Range(MinAge, MaxAge);
        info.BirthYear = DateTime.Now.Year - info.Age;
        info.DeathYear = DateTime.Now.Year;

        return info;
    


    }
}

public struct NPCBasicInformation
{
    public int BirthYear;
    public int DeathYear;
    public int Age;
    public string Name;
    public string Origin;
}
