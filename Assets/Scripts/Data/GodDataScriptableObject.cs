using UnityEngine;
using Zenject;
using System.Linq;
using System;

namespace Gatekeeper.Data
{

    public interface IGodDataProvider
    {
        GodData GetGodWithIndex(int index);
    }

    public class GodDataProvider : IGodDataProvider
    {
        [Inject]
        public GodData[] GodDatas;

        public GodData GetGodWithIndex(int index)
        {
            return GodDatas.FirstOrDefault(x => x.Index == index);
        }
    }

    [Serializable]
    public class GodData
    {
        public int Index;
        public string Name;
        public Sprite Image;
        public string Description;
        public int MinPointsBeforeGameOver = -100;

        public CauseOfDeath[] CauseOfDeathCriteria;
        public Origin[] OriginCriteria;
        public int AgeCriteriaMin;
        public int AgeCriteriaMax;
        public Name[] NameCriteria;
        public Ritual[] RitualCriteria;
    }

    [CreateAssetMenu(fileName = "GodData", menuName = "ScriptableObjects/GodDataScriptableObject", order = 1)]
    public class GodDataScriptableObject : ScriptableObjectInstaller<GodDataScriptableObject>
    {
        public GodData[] GodDatas;

        public override void InstallBindings()
        {
            Container.BindInstance(GodDatas);
        }
    }
}
