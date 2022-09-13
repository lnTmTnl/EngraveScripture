using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WoodenBoard : MonoBehaviour
{
    [SerializeField]
    private GameObject ui;
    [SerializeField]
    private GameObject scratchImage;
    [SerializeField]
    private GameObject mask;
    [SerializeField]
    private GameObject book;
    [SerializeField]
    private Canvas changeSceneCanvas;

    private Material material;

    // Start is called before the first frame update
    void Start()
    {
        material = gameObject.GetComponent<MeshRenderer>().material;
        SetTextures(null, null, Textures.WoodTexture);
        SetAlphas(1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        ResponseStep();
    }

    public void ResponseStep()
    {
        print(States.currentStep);
        //print(!Input.GetMouseButton(0));
        if (States.currentStep == Steps.Pasting)
        {
            SetTextures(null, Textures.WhiteTexture, Textures.WoodTexture);
            SetAlphas(1, 0.7f);
            Textures.BackedRenderTexture = GlobalFunctions.BakeTexture(GetComponent<MeshRenderer>().material);
            scratchImage.GetComponent<Image>().sprite = Sprite.Create(GlobalFunctions.toTexture2D(Textures.BackedRenderTexture), new Rect(0, 0, 512, 512), scratchImage.GetComponent<Image>().sprite.pivot);

            if(States.PasteOnBrush && States.HoldItem != null && States.HoldItem.ItemType == ItemTypes.Brush)
            {
                States.Drawable = true;
            }

            if (scratchImage.GetComponent<ScratchImage>().GetStatData().fillPercent > 0.95 && !Input.GetMouseButton(0))
            {
                SetTextures(Textures.Pages[0], null, Textures.PaperTexture);
                SetAlphas(0, 1);
                Textures.BackedRenderTexture = GlobalFunctions.BakeTexture(GetComponent<MeshRenderer>().material);

                book.SetActive(true);
                book.GetComponent<Book>().bookPages[0] = Sprite.Create(Textures.PaperTexture, new Rect(0, 0, 512, 512), book.GetComponent<Book>().bookPages[0].pivot);
                book.GetComponent<Book>().bookPages[1] = Sprite.Create(GlobalFunctions.toTexture2D(Textures.BackedRenderTexture), new Rect(0, 0, 512, 512), book.GetComponent<Book>().bookPages[1].pivot);
                book.GetComponent<Book>().bookPages[2] = scratchImage.GetComponent<Image>().sprite;

                SetTextures(Textures.Pages[0], Textures.PaperTexture, Textures.WoodTexture);
                SetAlphas(0.9f, 1);
                Textures.BackedRenderTexture = GlobalFunctions.BakeTexture(GetComponent<MeshRenderer>().material);
                scratchImage.GetComponent<Image>().sprite = Sprite.Create(GlobalFunctions.toTexture2D(Textures.BackedRenderTexture), new Rect(0, 0, 512, 512), scratchImage.GetComponent<Image>().sprite.pivot);
                mask.GetComponent<Image>().sprite = Sprite.Create(Textures.PaperTexture, new Rect(0, 0, 512, 512), mask.GetComponent<Image>().sprite.pivot);
                scratchImage.GetComponent<ScratchImage>().ResetMask();

                States.Drawable = false;
                States.currentStep = Steps.Flipping;
            }
        }
        else if (States.currentStep == Steps.Pressing)
        {

            //mask.GetComponent<Image>().sprite = Sprite.Create(Textures.PaperTexture, new Rect(0, 0, 512, 512), mask.GetComponent<Image>().sprite.pivot);

            if (scratchImage.GetComponent<ScratchImage>().GetStatData().fillPercent > 0.95 && !Input.GetMouseButton(0))
            {
                mask.GetComponent<Image>().sprite = Sprite.Create(GlobalFunctions.toTexture2D(Textures.BackedRenderTexture), new Rect(0, 0, 512, 512), mask.GetComponent<Image>().sprite.pivot);
                SetAlphas(0.6f, 1);
                Textures.BackedRenderTexture = GlobalFunctions.BakeTexture(GetComponent<MeshRenderer>().material);
                scratchImage.GetComponent<Image>().sprite = Sprite.Create(GlobalFunctions.toTexture2D(Textures.BackedRenderTexture), new Rect(0, 0, 512, 512), scratchImage.GetComponent<Image>().sprite.pivot);
                scratchImage.GetComponent<ScratchImage>().ResetMask();

                States.currentStep = Steps.Rubbing;
            }
        }
        else if (States.currentStep == Steps.Rubbing)
        {
            if (Input.GetMouseButton(0))
            {
                mask.GetComponent<Image>().sprite = Sprite.Create(GlobalFunctions.toTexture2D(Textures.BackedRenderTexture), new Rect(0, 0, 512, 512), mask.GetComponent<Image>().sprite.pivot);
                SetAlphas(0.3f, 1);
                Textures.BackedRenderTexture = GlobalFunctions.BakeTexture(GetComponent<MeshRenderer>().material);
                scratchImage.GetComponent<Image>().sprite = Sprite.Create(GlobalFunctions.toTexture2D(Textures.BackedRenderTexture), new Rect(0, 0, 512, 512), scratchImage.GetComponent<Image>().sprite.pivot);
                scratchImage.GetComponent<ScratchImage>().ResetMask();

                States.currentStep = Steps.Oiling;
            }
        }
        else if (States.currentStep == Steps.Oiling && !Input.GetMouseButton(0))
        {
            if (scratchImage.GetComponent<ScratchImage>().GetStatData().fillPercent > 0.95)
            {
                scratchImage.GetComponent<ScratchImage>().ResetMask();
                ui.SetActive(false);
                States.currentStep = Steps.Carving;
            }
        }
        else if (States.currentStep == Steps.Carving)
        {
            if (Input.GetMouseButton(0))
            {
                Textures.NormalTexture = GlobalFunctions.GetNormalTexture(Textures.Pages[0]);
                SetTextures(Textures.Pages[0], Textures.PaperTexture, Textures.WoodTexture, Textures.NormalTexture);
                changeSceneCanvas.gameObject.SetActive(true);
            }
        }
        else if (States.currentStep == Steps.Inking)
        {
            if (Textures.NormalTexture == null) Textures.NormalTexture = GlobalFunctions.GetNormalTexture(Textures.Pages[0]);
            SetTextures(Textures.Pages[0], Textures.PaperTexture, Textures.WoodTexture, Textures.NormalTexture);
            SetAlphas(0.3f, 1);
            Textures.BackedRenderTexture = GlobalFunctions.BakeTexture(GetComponent<MeshRenderer>().material);
            mask.GetComponent<Image>().sprite = Sprite.Create(GlobalFunctions.toTexture2D(Textures.BackedRenderTexture), new Rect(0, 0, 512, 512), mask.GetComponent<Image>().sprite.pivot);
            SetTextures(Textures.Pages[0], Textures.InkTexture, Textures.WoodTexture, Textures.NormalTexture);
            SetAlphas(1, 1);
            Textures.BackedRenderTexture = GlobalFunctions.BakeTexture(GetComponent<MeshRenderer>().material);
            //scratchImage.GetComponent<Image>().sprite = Sprite.Create(GlobalFunctions.toTexture2D(Textures.BackedRenderTexture), new Rect(0, 0, 512, 512), scratchImage.GetComponent<Image>().sprite.pivot);

            if (scratchImage.GetComponent<ScratchImage>().GetStatData().fillPercent > 0.99)
            {
                book.SetActive(true);
                States.currentStep = Steps.Printing;
            }
        }
    }

    public void OnPageCover()
    {
        book.SetActive(false);
        States.Drawable = true;
        States.currentStep = Steps.Pressing;
    }

    public void SetTextures(Texture2D UpperTexture2D, Texture2D MaskTexture2D, Texture2D BackgroundTexture2D, Texture2D NormalTexture = null)
    {
        material.SetTexture("_UpperTexture2D", UpperTexture2D);
        material.SetTexture("_MaskTexture2D", MaskTexture2D);
        material.SetTexture("_BackgroundTexture2D", BackgroundTexture2D);

        GetComponent<MeshRenderer>().material.SetTexture("_UpperTexture2D", UpperTexture2D);
        GetComponent<MeshRenderer>().material.SetTexture("_MaskTexture2D", MaskTexture2D);
        GetComponent<MeshRenderer>().material.SetTexture("_BackgroundTexture2D", BackgroundTexture2D);
        GetComponent<MeshRenderer>().material.SetTexture("_NormalTexture", NormalTexture);
    }

    public void SetAlphas(float MaskAlpha, float BackgroundAlpha)
    {
        material.SetFloat("_MaskAlpha", MaskAlpha);
        material.SetFloat("_BackgroundAlpha", BackgroundAlpha);

        GetComponent<MeshRenderer>().material.SetFloat("_MaskAlpha", MaskAlpha);
        GetComponent<MeshRenderer>().material.SetFloat("_BackgroundAlpha", BackgroundAlpha);
    }
}
