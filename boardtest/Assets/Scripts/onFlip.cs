using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onFlip : MonoBehaviour
{
    public GameObject book;
    public GameObject paper;
    public Canvas changeSceneCanvas;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onPrintFlip()
    {
        if (!States.Printed)
        {
            Vector2 pivot = this.book.GetComponent<Book>().bookPages[1].pivot;
            this.book.GetComponent<Book>().bookPages[1] = Sprite.Create(GlobalFunctions.toTexture2D(this.paper.GetComponent<BakeMaterial>().ResultTexture), new Rect(0, 0, 512, 512), pivot);
            States.Printed = true;
        }
        else
        {
            changeSceneCanvas.gameObject.SetActive(true);
            States.currentStep = Steps.Folding;
        }
    }
}
