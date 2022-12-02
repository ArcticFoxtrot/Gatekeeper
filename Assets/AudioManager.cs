using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Gatekeeper.Data;
using System;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private GameObject oneShotAudioSourcePrefab;

    [Inject]
    private IAudioDataProvider audioDataProvider;

    // Start is called before the first frame update
    void Start()
    {
        GameEventManager.OnGameEvent += HandleGameEvent;
    }

    private void OnDestroy()
    {
        GameEventManager.OnGameEvent -= HandleGameEvent;
    }

    private void HandleGameEvent(object sender, GameEvent gameEvent)
    {
        if (sender is GameManager gameManager)
        {
            Debug.Log("Got an event from game manager");
            if (gameEvent.Arguments[0] is GameState state && gameEvent.EventType == GameEvent.GameStateChanged)
            {
                switch (state)
                {
                    case GameState.MainMenu:
                        SwapAudioClipTo(AudioClipType.MenuMusic);
                        Debug.Log("Game state is main menu, playing main menu music");
                        break;
                    case GameState.Game:
                        Debug.Log("Game state is game, playing bg music");  
                        SwapAudioClipTo(AudioClipType.BackgroundMusic);
                        break;
                    case GameState.GameOver:
                        //not implemented
                        break;
                    default:
                        break;
                }
            }
        }
    }

    public void SwapAudioClipTo(AudioClipType clipType)
    {
        audioSource.Stop();
        var data = audioDataProvider.GetAudioData(clipType);
        audioSource.clip = data.AudioClip;
        audioSource.outputAudioMixerGroup = data.MixerGroup;
        audioSource.Play();
    }

    public void PlayOneShotAudio(AudioClipType clipType)
    {
        var data = audioDataProvider.GetAudioData(clipType);

        var oneShotAudioObject = Instantiate<GameObject>(oneShotAudioSourcePrefab, this.transform.position, Quaternion.identity, this.transform);

        if (oneShotAudioObject.TryGetComponent<OneShotAudioSource>(out OneShotAudioSource source))
        {
            source.Initialize(data.AudioClip, data.MixerGroup);
        }
    }
}
