using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllWoodenBoardStacks : MonoBehaviour
{
    private List<GameObject> StackObjs;

    // Start is called before the first frame update
    void Start()
    {
        StackObjs = new List<GameObject>();
        for (int i = 0; i < transform.childCount; i++)
        {
            StackObjs.Add(transform.GetChild(i).gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TurnOffAllStacks()
    {
        for(int i = 0; i < StackObjs.Count; i++)
        {
            StackObjs[i].GetComponent<WoodenBoardStack>().clickable = false;
        }
    }
}
