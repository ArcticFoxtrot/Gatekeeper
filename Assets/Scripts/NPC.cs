using System;
using UnityEngine;

public class NPC : MonoBehaviour 
{
    //visuals

    private GameObject Head;

    //documents
    //basic information

    public int Age;
    public string Name;
    public string Origin;
    public DateTime BirthDate;
    public DateTime DeathDate;
    public CauseOfDeathDocument CauseOfDeath;

    public void Initialize(GameObject head)
    {

    }
}

