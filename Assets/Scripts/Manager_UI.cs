using Newtonsoft.Json;
using SimplePopupManager;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

public class Manager_UI : MonoBehaviour
{
    [Inject] private IPopupManagerService _popupManager;
    [Inject] private Config_Leaderboard _leaderboardConfig;
    [Inject] private DiContainer _diContainer;

    public void OpenLeaderboard()
    {
        _popupManager.OpenPopup(_leaderboardConfig.popupAddressableName, _diContainer);
    }
}
