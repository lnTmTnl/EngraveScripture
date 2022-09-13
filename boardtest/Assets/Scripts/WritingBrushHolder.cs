using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WritingBrushHolder : MonoBehaviour
{
    [SerializeField]
    private GameObject itemObj;
    [SerializeField]
    private Sprite itemIcon;

    private bool clickable;

    // Start is called before the first frame update
    void Start()
    {
        clickable = true;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Outline>().enabled = clickable;
    }

    public void OnPenholderClicked()
    {
        if (!clickable) return;

        ItemsBar.Items.Add(new Item(ItemTypes.WritingBrush, itemObj, itemIcon));
        //ItemsBar.IconBars[ItemsBar.Items.Count - 1].transform.GetChild(0).gameObject.GetComponent<Image>().sprite = itemIcon;

        clickable = false;
        //States.penBrushInHand = true;
    }
}
