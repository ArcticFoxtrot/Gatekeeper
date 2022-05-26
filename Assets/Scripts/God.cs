using System;
using System.Collections.Generic;
using UnityEngine;

public class God
{
    public string Name;
    public string Description;
    private Sprite image;

    private int scoreWithGod;

    public God(string name, string description, Sprite image, int startingScore)
    {
        this.Name = name;
        this.Description = description;
        this.image = image;
        this.scoreWithGod = startingScore;
        
    }

    public List<ICriterion> PleasingCriteria;

    //god only knows what criteria pleases it
    //list<Criteria> pleasingCriteria

    //method that checks if handled NPC fulfills any criteria
    public void CheckCriteria(NPC npc, int multiplier)
    {
        foreach(var c in PleasingCriteria)
        {
            if(c.CheckForMatches(npc))
            {
                scoreWithGod += multiplier;
            }
        }
    }

    public void AssignCriteria(List<ICriterion> criteria)
    {
        PleasingCriteria = criteria;
    }

    public string GetGodDescription()
    {
        return String.Format("Name: {0} \nDescription: {1}", Name, Description);
    }

    public int GetScoreWithGod()
    {
        return scoreWithGod;
    }

    public void AddToScoreWithGod(int toAdd)
    {
        scoreWithGod += toAdd; // this could have a multiplier based on how volatile the god is in their opinions
        GameEventManager.Send(new GameEvent(this, GameEvent.ScoreChangedForGod,new object[]{this} ));
    }
}

