using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Installer_UI : MonoInstaller
{
    [SerializeField] private Config_UI _config_UI;

    public override void InstallBindings()
    {
        Container.Bind<Config_UI>().
            FromInstance(_config_UI).
            AsSingle();
    }
}
