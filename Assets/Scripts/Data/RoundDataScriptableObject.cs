using UnityEngine;
using System;
using Zenject;
using System.Linq;

namespace Gatekeeper.Data
{
    public interface IRoundDataProvider
    {
        public RoundData GetRoundData(int roundIndex);
    }

    public class RoundDataProvider : IRoundDataProvider
    {
        [Inject]
        public RoundData[] RoundDatas;

        public RoundData GetRoundData(int roundIndex)
        {
            return RoundDatas.FirstOrDefault(x => x.RoundIndex == roundIndex);
        }
    }

    [Serializable]
    public class RoundData
    {
        public int RoundIndex;
        public float RoundLength;
        public string RoundDescription;
        public int RoundNumberOfPeopleInQueue;
        public int RoundNumberOfOfficialCriteria;
    }


    [CreateAssetMenu(fileName = "RoundData", menuName = "ScriptableObjects/RoundDataScriptableObject", order = 1)]
    public class RoundDataScriptableObject : ScriptableObjectInstaller<RoundDataScriptableObject>
    {
        public RoundData[] RoundDatas;

        public override void InstallBindings()
        {
            Container.BindInstance(RoundDatas);
        }
    }

}