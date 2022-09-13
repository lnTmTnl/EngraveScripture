using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyboardControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnGUI()
    {
        if (Input.anyKeyDown)
        {
            Event e = Event.current;
            int keyCodeNumber = -1;
            if (e != null && e.isKey)
            {
                keyCodeNumber = (int)e.keyCode;
            }

            if(keyCodeNumber > -1)
            {
                if(keyCodeNumber >= 49 && keyCodeNumber < ItemsBar.Items.Count + 49)
                {
                    if(!ItemsBar.IsSelectedList[keyCodeNumber - 49]) { States.HoldItem = ItemsBar.Items[keyCodeNumber - 49]; }
                    else
                    {
                        States.HoldItem = null;
                        ItemsBar.IsSelectedList[keyCodeNumber - 49] = false;
                        ItemsBar.IconBars[keyCodeNumber - 49].GetComponent<Image>().color = new Color(1f, 1f, 1f, 0.3f);
                        return;
                    }
                    for (int i = 0; i < ItemsBar.IconBars.Count; i++)
                    {
                        ItemsBar.IconBars[i].GetComponent<Image>().color = new Color(1f, 1f, 1f, 0.3f);
                        ItemsBar.IsSelectedList[i] = false;
                    }
                    ItemsBar.IconBars[keyCodeNumber - 49].GetComponent<Image>().color = new Color(0f, 0f, 0f, 0.3f);
                    ItemsBar.IsSelectedList[keyCodeNumber - 49] = true;

                }
            }
        }
    }
}
