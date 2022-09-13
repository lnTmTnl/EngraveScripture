using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WoodenBoardTypes
{
    Pear,
    Camphor,
    Cherry,
    RedSandalwood
}

public class WoodenBoardStack : MonoBehaviour
{
    [SerializeField]
    private WoodenBoardTypes woodenType;
    [SerializeField]
    private int boardNumber;
    [SerializeField]
    private GameObject board;
    [SerializeField]
    private GameObject InfoBox;

    public bool clickable { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        CreateBoardStack();

        clickable = false;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Outline>().enabled = clickable;

        if(States.currentStep == Steps.Selecting)
        {
            clickable = true;
        }
        else
        {
            clickable = false;
        }
    }

    public void CreateBoardStack()
    {
        for(int i = 0; i < boardNumber; i++)
        {
            float xOffset = Random.Range(-2, 2);
            float zOffset = Random.Range(-2, 2);
            GameObject cloneBoard = Instantiate(board, this.transform);
            cloneBoard.transform.localPosition = new Vector3(xOffset, i * cloneBoard.transform.localScale.y, zOffset);
        }
    }

    public void OnWoodenBoardStackClicked()
    {
        if (!clickable) return;

        InfoBox.SetActive(true);
        InfoBox.GetComponent<WoodInfoBox>().Type = woodenType;
    }
}
