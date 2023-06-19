using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class LocalDataLoader
{
    public async Task<string> LoadAddressableJson(string name)
    {
        AsyncOperationHandle<TextAsset> handle = Addressables.LoadAssetAsync<TextAsset>(name);

        await handle.Task;

        return handle.Result.text;
    }

    public async Task<GameObject> LoadAddressableGameObject(string name)
    {
        AsyncOperationHandle<GameObject> handle = Addressables.LoadAssetAsync<GameObject>(name);

        await handle.Task;

        return handle.Result;
    }
}
