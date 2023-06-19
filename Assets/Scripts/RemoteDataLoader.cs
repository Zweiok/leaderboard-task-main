using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;
using Zenject;

public class RemoteDataLoader
{
    public async Task<Texture2D> DownloadTextureFromPath(string path)
    {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(path);
        request.SendWebRequest();

        while (!request.isDone) 
            await Task.Yield();

        if (request.result == UnityWebRequest.Result.ConnectionError 
            || request.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.Log("Error: " + request.error);
            return null;
        }
        return DownloadHandlerTexture.GetContent(request);
    }
}
