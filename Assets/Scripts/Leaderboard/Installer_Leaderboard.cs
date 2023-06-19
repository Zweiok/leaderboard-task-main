using SimplePopupManager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Installer_Leaderboard : MonoInstaller
{
    [SerializeField] private Config_Leaderboard _leaderboardConfig;
    public override void InstallBindings()
    {
        Container.Bind<Config_Leaderboard>().
            FromInstance(_leaderboardConfig).
            AsSingle();
    }
}
