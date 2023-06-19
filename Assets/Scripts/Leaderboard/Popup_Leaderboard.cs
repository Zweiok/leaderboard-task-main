using Newtonsoft.Json;
using SimplePopupManager;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Events;
using Zenject;

public class Popup_Leaderboard : MonoBehaviour, IPopupInitialization
{
    [SerializeField] private ListItem_Leaderboard _listItem;

    [Inject] private Config_Leaderboard _leaderboardConfig;
    [Inject] private LocalDataLoader _localDataLoader;
    [Inject] private IPopupManagerService _popupManagerService;
    [Inject] private RemoteDataLoader _remoteDataLoader;
    [Inject] private DiContainer _diContainer;
    [Inject] private Config_UI _config_UI;

    private GameObject _imageLoadingPrefab;

    public async Task Init(object param)
    {
        (param as DiContainer).Inject(this); 

        _imageLoadingPrefab = await _localDataLoader.LoadAddressableGameObject(_config_UI.loadingAddressableName);

        InitializeLeaderboard(JsonConvert.DeserializeObject<PopupInitData_Leaderboard>(
                await _localDataLoader.LoadAddressableJson(_leaderboardConfig.jsonAddressableName)));
    }

    public void ClosePopup()
    {
        _popupManagerService.ClosePopup(_leaderboardConfig.popupAddressableName);
    }

    private void InitializeLeaderboard(PopupInitData_Leaderboard initData)
    {
        foreach(var item in initData.leaderboard)
        {
            SpawnListItem(item);
        }
    }

    private async void SpawnListItem(PlayerData_Leaderboard data)
    {
        ListItem_Leaderboard newItem = _diContainer.InstantiatePrefab(_listItem, _listItem.transform.parent).GetComponent<ListItem_Leaderboard>();

        newItem.gameObject.SetActive(true);

        newItem.SetupData(data, _leaderboardConfig.GetRankTextSettings(data.type));

        Task<Texture2D> textureLoading = _remoteDataLoader.DownloadTextureFromPath(data.avatar);

        SetLoadingObjectTo(textureLoading, newItem.AvatarIco.transform);

        await textureLoading;

        newItem.SetImageTexture(textureLoading.Result);
    }

    private async void SetLoadingObjectTo(Task whileTask, Transform loaderObjTransform)
    {
        GameObject loaderObj = Instantiate(_imageLoadingPrefab, loaderObjTransform.parent);

        await whileTask;

        DestroyImmediate(loaderObj);
    }

    private void OnDestroy()
    {
        Addressables.ReleaseInstance(_imageLoadingPrefab);
    }
}
