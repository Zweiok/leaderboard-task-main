using SimplePopupManager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Installer_PopupManager : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<IPopupManagerService>().
            To<PopupManagerServiceService>().
            AsSingle();
    }
}
