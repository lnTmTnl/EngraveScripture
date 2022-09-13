using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Carve : MonoBehaviour
{
    private bool clickable;
    private Sprite sprite;

    // Start is called before the first frame update
    void Start()
    {
        clickable = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AutoCarve()
    {
        if (this.GetComponent<ScratchImage>().GetStatData().fillPercent < 0.95f) return;
        if (!clickable) return;
        sprite = Sprite.Create(GlobalFunctions.toTexture2D(Framework.CharacterWriter.Draw.CarvedPearDrawnRenderTex), new Rect(0, 0, 512, 512), this.GetComponent<Image>().sprite.pivot);
        this.GetComponent<Image>().sprite = sprite;
        clickable = false;
    }
}
