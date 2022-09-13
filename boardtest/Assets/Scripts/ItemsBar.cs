using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemsBar : MonoBehaviour
{

    public static List<Item> Items;
    public static List<GameObject> IconBars;
    public static List<bool> IsSelectedList;

    private int itemsCount;

    void Start()
    {
        Items = new List<Item>();
        IconBars = new List<GameObject>();
        IsSelectedList = new List<bool>();
        for (int i = 0; i < transform.childCount; i++)
        {
            IconBars.Add(transform.GetChild(i).gameObject);
            IsSelectedList.Add(false);
        }
        itemsCount = Items.Count;
    }

    // Update is called once per frame
    void Update()
    {
        if(itemsCount != Items.Count)
        {
            for(int i = 0; i < Items.Count; i++)
            {
                IconBars[i].transform.GetChild(0).gameObject.GetComponent<Image>().sprite = Items[i].ItemIcon;
            }
        }
    }
}
