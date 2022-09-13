using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public static class GlobalFunctions
{
    public static Texture2D toTexture2D(RenderTexture rTex)
    {
        Texture2D tex = new Texture2D(512, 512, TextureFormat.RGB24, false);
        // ReadPixels looks at the active RenderTexture.
        RenderTexture.active = rTex;
        tex.ReadPixels(new Rect(0, 0, rTex.width, rTex.height), 0, 0);
        tex.Apply();
        return tex;
    }

    public static Texture2D GetNormalTexture(Texture2D tex1)
    {
        int W = tex1.width;
        int H = tex1.height;
        Texture2D tex2 = new Texture2D(W, H);
        for (int i = 1; i < W - 1; i++)
        {
            for (int j = 1; j < H - 1; j++)
            {
                Color c;
                c = tex1.GetPixel(i - 1, j);
                float left = (c.r + c.g + c.b) / 3;
                c = tex1.GetPixel(i + 1, j);
                float right = (c.r + c.g + c.b) / 3;
                c = tex1.GetPixel(i, j + 1);
                float top = (c.r + c.g + c.b) / 3;
                c = tex1.GetPixel(i, j - 1);
                float bottom = (c.r + c.g + c.b) / 3;

                float u = right - left;
                float v = bottom - top;

                Vector3 ve3_U = new Vector3(1, 0, u);
                Vector3 ve3_V = new Vector3(0, 1, v);

                Vector3 N = Vector3.Cross(ve3_U, ve3_V).normalized;

                float r = N.x * 0.5f + 0.5f;
                float g = N.y * 0.5f + 0.5f;
                float b = N.z * 0.5f + 0.5f;

                tex2.SetPixel(i, j, new Color(r, g, b));
            }
        }
        tex2.Apply(false);

        /*byte[] arr = tex2.EncodeToPNG();
        using (FileStream fs = new FileStream(Application.dataPath + "/Images/Textures/normal textures/NormalTexture.png", FileMode.OpenOrCreate))
        {
            fs.Write(arr, 0, arr.Length);
        }*/

        return tex2;
    }

    public static RenderTexture BakeTexture(Material material, int Size = 512)
    {
        RenderTexture ResultTexture = new RenderTexture(Size, Size, 0);
        Graphics.Blit(material.mainTexture, ResultTexture, material);
        return ResultTexture;
    }
}
