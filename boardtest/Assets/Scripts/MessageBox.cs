using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageBox : MonoBehaviour
{
    [SerializeField]
    private Text MessageText;
    [SerializeField]
    private Button OKBtn;
    [SerializeField]
    private Button NextBtn;
    [SerializeField]
    private GameObject WoodenBoard;

    private WoodenBoardTypes type;
    public WoodenBoardTypes Type
    {
        get { return type; }
        set
        {
            type = value;
            if(type == WoodenBoardTypes.Pear)
            {
                MessageText.text = "Right";
                OKBtn.gameObject.SetActive(false);
                NextBtn.gameObject.SetActive(true);
            }
            else
            {
                MessageText.text = "Wrong";
                OKBtn.gameObject.SetActive(true);
                NextBtn.gameObject.SetActive(false);
            }
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

    public void OnOKBtnClicked()
    {
        gameObject.SetActive(false);
    }

    public void OnNextBtnClicked()
    {
        WoodenBoard.SetActive(true);
        States.WoodenBoardOnTable = true;
        gameObject.SetActive(false);
        States.currentStep = Steps.Pasting;
    }
}
