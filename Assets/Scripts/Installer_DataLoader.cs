using SimplePopupManager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Installer_DataLoader : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<RemoteDataLoader>().
            FromInstance(new RemoteDataLoader()).
            AsSingle();

        Container.Bind<LocalDataLoader>().
            FromInstance(new LocalDataLoader()).
            AsSingle();
    }
}
