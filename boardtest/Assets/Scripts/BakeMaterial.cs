using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BakeMaterial : MonoBehaviour {
    public RenderTexture ResultTexture;
    public int Size = 1024;

    public Material ReplaceMaterial;

	// Use this for initialization
	void Awake () {
        if (ResultTexture == null)
        {
            ResultTexture = new RenderTexture(Size, Size, 0);
            ResultTexture.name = "Baked Texture";
        }

        bakeTexture();

        if (ReplaceMaterial != null)
        {
            ReplaceMaterial.mainTexture = ResultTexture;
        }
	}

    void bakeTexture()
    {
        var material = GetComponent<RawImage>() != null ? Instantiate(GetComponent<RawImage>().material) : Instantiate(GetComponent<MeshRenderer>().material);
        Graphics.Blit(material.mainTexture, ResultTexture, material);
        Textures.BackedRenderTexture = ResultTexture;
    }
}
