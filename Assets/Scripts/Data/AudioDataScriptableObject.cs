using UnityEngine;
using Zenject;
using System;
using System.Linq;
using UnityEngine.Audio;

namespace Gatekeeper.Data
{
    public interface IAudioDataProvider 
    {
        public AudioData GetAudioData(AudioClipType clipType);
    }

    public class AudioDataProvider : IAudioDataProvider
    {
        [Inject]
        public AudioData[] AudioDatas;

        public AudioData GetAudioData(AudioClipType clipType)
        {
            return AudioDatas.FirstOrDefault(x => x.ClipType == clipType);
        }
    }

    [Serializable]
    public class AudioData
    {
        public AudioClipType ClipType;
        public AudioClip AudioClip;
        public AudioMixerGroup MixerGroup;
    }

    public enum AudioClipType
    {
        BackgroundMusic,
        MenuMusic,
        ButtonClick
    }

    [CreateAssetMenu(fileName = "AudioData", menuName = "ScriptableObjects/AudioDataScriptableObject", order = 1)]
    public class AudioDataScriptableObject : ScriptableObjectInstaller<AudioDataScriptableObject>
    {
        public AudioData[] AudioDatas;

        public override void InstallBindings()
        {
            Container.BindInstance(AudioDatas);
        }
    }
}