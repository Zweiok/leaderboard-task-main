using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utils
{
    public static Texture2D FromBytes_CreateTexture2D(byte[] textureBytes)
    {
        Texture2D texture = new Texture2D(1, 1);
        texture.LoadRawTextureData(textureBytes);
        return texture;
    }
}
