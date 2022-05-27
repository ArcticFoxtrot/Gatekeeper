using System.Collections.Generic;

public class Player
{
    public int TotalScore;
    public PlayerPosition CurrentPosition;
}

public enum Rank
{
    Intern,
    JuniorClerk,
    Clerk,
    SeniorClerk,
    LeadClerk,
    ClerkSupreme,
    GateKeeper
}

public class PlayerPosition
{
    public Rank Rank;
    public List<Tool> ToolsAvailable = new List<Tool>();
    public int ScoreRequired;
}

public class Tool
{

}

