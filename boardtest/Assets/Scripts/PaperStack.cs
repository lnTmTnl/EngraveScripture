using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperStack : MonoBehaviour
{
    [SerializeField]
    private GameObject pages;
    [SerializeField]
    private GameObject paper;

    private bool clickable;

    void Start()
    {
        States.PaperOnTable = false;
        CopyToBeStacks(pages, 50);
    }
    
    void Update()
    {
        if(States.currentStep == Steps.Writing && !States.PaperOnTable)
        {
            clickable = true;
        }
        else if(States.currentStep == Steps.Folding && !States.PaperOnTable && this.name == "PaperStack")
        {
            clickable = true;
        }
        else if(States.currentStep == Steps.Protector && !States.FoldPaperProtected && this.name == "ProtectorPaperStack")
        {
            clickable = true;
        }
        else if (States.currentStep == Steps.Coverring && !States.BookCoverred && this.name == "CoverStack")
        {
            clickable = true;
        }
        else
        {
            clickable = false;
        }

        gameObject.GetComponent<Outline>().enabled = clickable;
    }

    public void OnPaperStackClicked()
    {
        if (!clickable) return;

        if (States.currentStep == Steps.Writing)
        {
            PlacePaper();
            paper.gameObject.GetComponent<MeshRenderer>().material.SetTexture("_UpperTexture2D", null);
            States.PaperOnTable = true;
        }
        else if (States.currentStep == Steps.Folding)
        {
            PlacePaper();
            States.PaperOnTable = true;
        }
        else if (States.currentStep == Steps.Protector)
        {
            PlacePaper();
            States.FoldPaperProtected = true;
            States.currentStep = Steps.Coverring;
        }
        else if (States.currentStep == Steps.Coverring)
        {
            PlacePaper();
            States.BookCoverred = true;
            States.FoldPaperProtected = true;
            States.currentStep = Steps.Punching;
        }
    }

    private void PlacePaper()
    {
        if (!paper.activeSelf)
        {
            paper.SetActive(true);
            clickable = false;
        }
    }

    private void CopyToBeStacks(GameObject obj, int num)
    {
        for (int i = 0; i < num; i++)
        {
            float xOffset = Random.Range(-2, 2);
            float zOffset = Random.Range(-2, 2);
            GameObject cloneObj = Instantiate(obj, this.transform);

            cloneObj.transform.localPosition = new Vector3(xOffset + cloneObj.transform.localPosition.x, i / 10 + cloneObj.transform.localPosition.y, zOffset + cloneObj.transform.localPosition.z);
        }
    }
}
