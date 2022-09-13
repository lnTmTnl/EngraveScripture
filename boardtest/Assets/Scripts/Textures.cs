using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Textures : MonoBehaviour
{
    [SerializeField]
    private List<Texture2D> pages;
    [SerializeField]
    private Texture2D paperTexture;
    [SerializeField]
    private Texture2D woodTexture;
    [SerializeField]
    private Texture2D inkTexture;
    [SerializeField]
    private Texture2D normalTexture;
    [SerializeField]
    private Texture2D whiteTexture;
    [SerializeField]
    private Texture2D blackTexture;

    public static List<Texture2D> Pages { get; private set; }
    public static Texture2D PaperTexture { get; private set; }
    public static Texture2D WoodTexture { get; private set; }
    public static Texture2D InkTexture { get; private set; }
    public static Texture2D NormalTexture { get; set; }
    public static Texture2D WhiteTexture { get; private set; }
    public static Texture2D BlackTexture { get; private set; }
    public static RenderTexture BackedRenderTexture { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        Pages = pages;
        PaperTexture = paperTexture;
        WoodTexture = woodTexture;
        NormalTexture = normalTexture;
        InkTexture = inkTexture;
        WhiteTexture = whiteTexture;
        BlackTexture = blackTexture;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
