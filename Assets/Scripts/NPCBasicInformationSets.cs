using System;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "NPCBasicInformationSets", menuName = "ScriptableObjects/Documents/NPCBasicInformationSets", order = 1)]
public class NPCBasicInformationSets : ScriptableObject
{
    public int MinAge;
    public int MaxAge;

    public Name[] Names;
    public Origin[] Origins;

 
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

public struct NPCBasicInformation : IDocument
{
    public int BirthYear;
    public int DeathYear;
    public int Age;
    public Name Name;
    public Origin Origin;
    public Ritual Ritual;

    public string ReadDocument()
    {
        return String.Format("Name: {0} \nAge : {1} \nBirth: {2} \nFrom: {3}", Name, Age, BirthYear, Origin.ToString());
    }
}
