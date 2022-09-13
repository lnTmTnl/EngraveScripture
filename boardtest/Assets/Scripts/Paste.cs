using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Paste : MonoBehaviour
{
    [SerializeField]
    private GameObject WoodenBoardUI;
    [SerializeField]
    private GameObject XuanzhiBook;
    [SerializeField]
    private GameObject woodenBoard;
    //public RenderTexture rt;

    private bool clickable;

    void Start()
    {
        clickable = false;
    }

    void Update()
    {
        gameObject.GetComponent<Outline>().enabled = clickable;

        if (States.currentStep == Steps.Pasting && States.WoodenBoardOnTable && States.HoldItem != null && States.HoldItem.ItemType == ItemTypes.Brush)
        {
            clickable = true;
        }
        else
        {
            clickable = false;
        }
    }

    public void OnPasteClicked()
    {
        if (!clickable) return;

        if (woodenBoard.gameObject.activeSelf)
        {
            //woodenBoard.SetActive(true);
            WoodenBoardUI.gameObject.SetActive(true);
            States.WoodenBoardOnTable = true;
            States.PasteOnBrush = true;

            //States.Drawable = true;
            //XuanzhiBook.GetComponent<Book>().bookPages[1]
            //rt = Textures.BackedRenderTexture;
            //RenderTexture renderTexture = RenderTexture.GetTemporary(512, 512);
            //Graphics.Blit(rt, renderTexture);
            
            //XuanzhiBook.GetComponent<Book>().bookPages[1] = Sprite.Create(GlobalFunctions.toTexture2D(renderTexture), new Rect(0, 0, 512, 512), XuanzhiBook.GetComponent<Book>().bookPages[1].pivot);
            //woodenBoard.GetComponent<WoodenBoard>().SetTextures(Textures.Pages[0], Textures.PaperTexture, Textures.WoodTexture);
            //woodenBoard.GetComponent<WoodenBoard>().SetAlphas(1f, 0.6f);
        }
    }
}
