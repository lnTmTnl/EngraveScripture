using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ink : MonoBehaviour
{

    [SerializeField]
    private GameObject paper;
    //private Canvas DrawCanvas;

    private bool clickable;

    void Start()
    {
        clickable = false;
    }
    
    void Update()
    {
        gameObject.GetComponent<Outline>().enabled = clickable;

        if (States.currentStep == Steps.Writing && States.PaperOnTable && States.HoldItem != null && States.HoldItem.ItemType == ItemTypes.WritingBrush)
        {
            clickable = true;
        }
        else
        {
            clickable = false;
        }
    }

    public void OnInkClicked()
    {
        if (!clickable) return;

        if (paper.gameObject.activeSelf)
        {
            paper.gameObject.GetComponent<MeshRenderer>().material.SetTexture("_UpperTexture2D", Textures.Pages[0]);
            States.currentStep = Steps.Selecting;
            //DrawCanvas.gameObject.SetActive(true);

            //States.Drawable = true;
        }
        else
        {
            paper.gameObject.SetActive(true);
        }
    }
}
