using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class WoodInfoBox : MonoBehaviour
{
    [SerializeField]
    private Text titleText;
    [SerializeField]
    private Text infoText;
    [SerializeField]
    private GameObject AllWoodenBoardStacks;
    [SerializeField]
    private GameObject MessageBox;
    [SerializeField]
    private GameObject paper;
    [SerializeField]
    private TextAsset JsonFile;

    private WoodenBoardTypes type;
    public WoodenBoardTypes Type
    {
        get { return type; }
        set
        {
            type = value;
            GetInfoFromJson(type);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetInfoFromJson(WoodenBoardTypes woodType)
    {
        int index = (int)woodType;
        string jsonData = JsonFile.text;
        JsonWoodInfosArray obj = JsonUtility.FromJson<JsonWoodInfosArray>(jsonData);
        JsonWoodInfoModel item = obj.WoodInfos[index];
        titleText.text = item.name;
        infoText.text = item.info;
    }

    public void OnCloseBtnClicked()
    {
        gameObject.SetActive(false);
    }

    public void OnSelectBtnClicked()
    {
        if (Type == WoodenBoardTypes.Pear)
        {
            AllWoodenBoardStacks.GetComponent<AllWoodenBoardStacks>().TurnOffAllStacks();
        }
        MessageBox.SetActive(true);
        MessageBox.GetComponent<MessageBox>().Type = Type;
        paper.SetActive(false);
        gameObject.SetActive(false);
    }
}
