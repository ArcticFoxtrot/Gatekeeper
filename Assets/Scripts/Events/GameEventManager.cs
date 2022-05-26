using System;

public class GameEvent
{
    public string EventType;
    public object[] Arguments;
    public object Sender;

    ///<summary>
    /// GameEvents relate to events which alter the state of the game
    ///</summary>
    public GameEvent(object sender, string eventType, object[] args = null)
    {
        Sender = sender;
        EventType = eventType;
        Arguments = args;
    }

    public const string NPCCreated = "NPCCreated";
    public const string NextNPCReady = "NextNPCReady";
    public const string EntryApproved = "EntryApproved";
    public const string EntryNotApproved = "EntryNotApproved";
    public const string SentToEarth = "SentToEarth";
    public const string NPCReachedDestination = "NPCReachedDestination";
    public const string EndOfTime = "EndOfTime";
    public const string NewGodCreated = "NewGodCreated";
    public const string PlayerScoreChanged = "PlayerScoreChanged";
    public const string OfficialCriteriaAdded = "OfficialCriteriaAdded";
    public const string RoundStarted = "RoundStarted";
    public const string StartNewShift = "StartNewShift";
}

public static class GameEventManager
{

    public static event EventHandler<GameEvent> OnGameEvent;

    public static void Send(GameEvent newEvent)
    {
        if(OnGameEvent != null)
        {
            OnGameEvent(newEvent.Sender, newEvent);
        }
    }


}