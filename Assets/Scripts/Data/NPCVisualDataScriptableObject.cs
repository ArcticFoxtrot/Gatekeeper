using UnityEngine;
using Zenject;
using System;

namespace Gatekeeper.Data
{
    public interface INPCVisualDataProvider
    {
        public Sprite GetRandomHair();
        public Sprite GetRandomEyebrow();
        public Sprite GetRandomEyes();
        public Sprite GetRandomNose();
        public Sprite GetRandomEar();
        public Sprite GetRandomMouth();
        public GameObject GetRandomHead();
    }

    [Serializable]
    public class VisualsData
    {
        public Sprite[] HairSprites;

        public Sprite[] EyeBrowSprites;

        public Sprite[] EyeSprites;

        public Sprite[] NoseSprites;

        public Sprite[] EarSprites;

        public Sprite[] MouthSprites;

        public GameObject[] HeadPrefabs;
    }

    public class NPCVisualDataProvider : INPCVisualDataProvider
    {
        [Inject]
        public VisualsData VisualsData;
        public Sprite GetRandomHair()
        {
            int randomInt = UnityEngine.Random.Range(0, VisualsData.HairSprites.Length - 1);
            return VisualsData.HairSprites[randomInt];
        }
        public Sprite GetRandomEyebrow()
        {
            int randomInt = UnityEngine.Random.Range(0, VisualsData.EyeBrowSprites.Length - 1);
            return VisualsData.EyeBrowSprites[randomInt];
        }
        public Sprite GetRandomEyes()
        {
            int randomInt = UnityEngine.Random.Range(0, VisualsData.EyeSprites.Length - 1);
            return VisualsData.EyeSprites[randomInt];
        }
        public Sprite GetRandomNose()
        {
            int randomInt = UnityEngine.Random.Range(0, VisualsData.NoseSprites.Length - 1);
            return VisualsData.NoseSprites[randomInt];
        }
        public Sprite GetRandomEar()
        {
            int randomInt = UnityEngine.Random.Range(0, VisualsData.EarSprites.Length - 1);
            return VisualsData.EarSprites[randomInt];
        }
        public Sprite GetRandomMouth()
        {
            int randomInt = UnityEngine.Random.Range(0, VisualsData.MouthSprites.Length - 1);
            return VisualsData.MouthSprites[randomInt];
        }
        public GameObject GetRandomHead()
        {
            int randomInt = UnityEngine.Random.Range(0, VisualsData.HeadPrefabs.Length - 1);
            return VisualsData.HeadPrefabs[randomInt];
        }
    }


    [CreateAssetMenu(fileName = "NPCVisualData", menuName = "ScriptableObjects/NPCVisualDataScriptableObject", order = 1)]
    public class NPCVisualDataScriptableObject : ScriptableObjectInstaller<NPCVisualDataScriptableObject>
    {
        public VisualsData VisualsData;

        public override void InstallBindings()
        {
            Container.BindInstance(VisualsData);
        }
    }
}