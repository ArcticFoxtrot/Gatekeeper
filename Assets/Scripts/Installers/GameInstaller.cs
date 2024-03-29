using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Gatekeeper.Data
{
    public class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<GodDataProvider>().AsSingle();
            Container.BindInterfacesAndSelfTo<NPCVisualDataProvider>().AsSingle();
            Container.BindInterfacesAndSelfTo<NPCDataProvider>().AsSingle();
            Container.BindInterfacesAndSelfTo<RoundDataProvider>().AsSingle();
            Container.BindInterfacesAndSelfTo<PlayerRankDataProvider>().AsSingle();
            Container.BindInterfacesAndSelfTo<AudioDataProvider>().AsSingle();
        }
    }
}

