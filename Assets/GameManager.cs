using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Zenject;

public interface IGameStateHandler
{
    public static EventHandler<GameEvent> OnGameStateChanged;
    public GameState GetGameState();
}

public class GameManager : MonoBehaviour, IGameStateHandler
{
    ///<summary>
    ///Handles game state management so we can handle most things in one scene with multiple states transitioning
    ///</summary>
    public static event EventHandler<GameEvent> OnGameStateChanged;
    private GameState gameState;

    private void Start()
    {
        SetGameState(GameState.MainMenu);
    }

    public void SetGameState(GameState setToState)
    {
        gameState = setToState;
        GameEvent gameEvent = new GameEvent(this, GameEvent.GameStateChanged, new object[] { gameState });
        GameEventManager.Send(gameEvent);
        Debug.Log("Game state has been set to " + setToState);
    }

    public GameState GetGameState()
    {
        throw new NotImplementedException();
    }
}

public enum GameState
{
    MainMenu,
    Game,
    GameOver
}
