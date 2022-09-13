using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Steps
{
    Writing,
    Selecting,
    Pasting,
    Flipping,
    Pressing,
    Rubbing,
    Oiling,
    Carving,
    Inking,
    Printing,
    Folding,
    Sorting,
    Protector,
    Coverring,
    Punching,
    Lining,
    Finished
}
public class States : MonoBehaviour
{
   public static bool PaperOnTable { get; set; }
    public static bool Drawable { get; set; }
    public static bool WoodenBoardOnTable { get; set; }
    public static bool PasteOnBrush { get; set; }
    public static bool Printed { get; set; }
    public static bool FoldPaperSorted { get; set; }
    public static bool FoldPaperProtected { get; set; }
    public static bool BookCoverred { get; set; }

    public static GameObject HoldItemObj { get; private set; }

    public static Steps currentStep { get; set; }

    private static Item holdItem;
    public static Item HoldItem {
        get { return holdItem; }
        set {
            if(HoldItemObj != null) { Destroy(HoldItemObj); }
            holdItem = value;
            if (holdItem != null) { HoldItemObj = Instantiate(value.ItemObj, Camera.main.transform); }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        currentStep = Steps.Writing;
        PaperOnTable = false;
        Drawable = false;
        WoodenBoardOnTable = false;
        PasteOnBrush = false;
        Printed = false;
        FoldPaperSorted = false;
        FoldPaperProtected = false;
        BookCoverred = false;
        //penBrushInHand = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(HoldItemObj != null)
        {
            Vector3 m_MousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);
            HoldItemObj.transform.position = Camera.main.ScreenToWorldPoint(m_MousePos);
        }
    }
}
