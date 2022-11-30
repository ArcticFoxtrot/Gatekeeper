using UnityEngine;
using Zenject;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Gatekeeper.Data
{
    public interface IPlayerRankDataProvider
    {
        public PlayerRankData GetRankWithPoints(int points);
    }

    public class PlayerRankDataProvider : IPlayerRankDataProvider
    {
        [Inject]
        PlayerRankData[] PlayerRankDatas;
        public PlayerRankData GetRankWithPoints(int points)
        {
            List<PlayerRankData> ranks = PlayerRankDatas.ToList();
            List<PlayerRankData> ranksOrdered = ranks.OrderBy(o => o.ScoreRequired).ToList();
            int returnRank = 0;
            for (int i = ranksOrdered.Count - 1; i >= 0; i--)
            {
                if (ranksOrdered[i].ScoreRequired > points)
                {
                    returnRank = i == 0 ? 0 : i - 1;
                }
            }

            return ranksOrdered[returnRank];
        }
    }

    [Serializable]
    public class PlayerRankData
    {
        public Rank Rank;
        public int ScoreRequired;
    }

    [CreateAssetMenu(fileName = "PlayerRankData", menuName = "ScriptableObjects/PlayerRankDataScriptableObject", order = 1)]
    public class PlayerRankDataScriptableObject : ScriptableObjectInstaller<PlayerRankDataScriptableObject>
    {
        public PlayerRankData[] PlayerRankDatas;

        public override void InstallBindings()
        {
            Container.BindInstance(PlayerRankDatas);
        }
    }

}