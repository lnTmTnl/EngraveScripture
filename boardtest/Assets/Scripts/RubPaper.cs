using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RubPaper : MonoBehaviour
{
    public GameObject woodenBoard;
    public GameObject scratchImage;
    public Image mask;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onClick()
    {
        //if (scratchImage.GetComponent<ScratchImage>().clickable && scratchImage.GetComponent<ScratchImage>().flapped)
        {
            AutoRubPaper();
        }
        //if (scratchImage.GetComponent<ScratchImage>().clickable && scratchImage.GetComponent<ScratchImage>().oiled)
        {
            AutoCarve();
        }
    }

    public void AutoRubPaper()
    {
        //scratchImage.GetComponent<ScratchImage>().flapped = false;
        //scratchImage.GetComponent<ScratchImage>().rubbed = true;
        //scratchImage.GetComponent<ScratchImage>().clickable = false;
        scratchImage.GetComponent<ScratchImage>().ResetMask();
        woodenBoard.GetComponent<WoodenBoard>().SetAlphas(0.8f, 0.8f);
        Textures.BackedRenderTexture = GlobalFunctions.BakeTexture(woodenBoard.GetComponent<MeshRenderer>().material);
        mask.sprite = Sprite.Create(GlobalFunctions.toTexture2D(Textures.BackedRenderTexture), new Rect(0, 0, 512, 512), mask.sprite.pivot);
        woodenBoard.GetComponent<WoodenBoard>().SetAlphas(0, 1);
    }

    public void AutoCarve()
    {
        //scratchImage.GetComponent<ScratchImage>().oiled = false;
        //scratchImage.GetComponent<ScratchImage>().carved = true;
        //scratchImage.GetComponent<ScratchImage>().clickable = false;
        woodenBoard.GetComponent<WoodenBoard>().SetTextures(Textures.Pages[0], Textures.InkTexture, Textures.WoodTexture, Textures.NormalTexture);
    }
}
