using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoldPaperController : MonoBehaviour
{
    [SerializeField]
    private GameObject pages;
    [SerializeField]
    private GameObject paperLeft;
    [SerializeField]
    private GameObject paperRight;

    private List<GameObject> clonedPagesList;

    private bool isFold;

    void Start()
    {
        clonedPagesList = new List<GameObject>();
        //paperLeft.transform.rotation = Quaternion.Euler(0, 0, 0);
        //paperRight.transform.rotation = Quaternion.Euler(0, 0, 0);

        isFold = false;

        CopyToBeStacks(pages, 50);
    }

    // Update is called once per frame
    void Update()
    {
        //print(paperLeft.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("FoldPaperLeft") && paperLeft.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0);
        if(isFold && paperLeft.transform.localRotation.z <= -0.7 && !(paperLeft.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("FoldPaperLeft") && paperLeft.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0))
        {
            CopyToBeStacks(pages, 50);
            isFold = false;
            States.currentStep = Steps.Sorting;
        }
    }

    public void OnFoldPaperClick()
    {
        if(States.currentStep == Steps.Folding)
        {
            FoldPaper();
            for (int i = 0; i < clonedPagesList.Count; i++)
            {
                Destroy(clonedPagesList[i]);
            }
            clonedPagesList.Clear();
            isFold = true;
        }
        else if(States.currentStep == Steps.Sorting)
        {
            for (int i = 0; i < clonedPagesList.Count; i++)
            {
                clonedPagesList[i].transform.position = new Vector3(pages.transform.position.x, clonedPagesList[i].transform.position.y, pages.transform.position.z);
            }
            States.currentStep = Steps.Protector;
        }
    }

    private void FoldPaper()
    {
        paperLeft.GetComponent<Animator>().Play("FoldPaperLeft", 0);
    }
    
    private void CopyToBeStacks(GameObject obj, int num)
    {
        for (int i = 0; i < num; i++)
        {
            float xOffset = Random.Range(-2, 2);
            float zOffset = Random.Range(-2, 2);
            GameObject cloneObj = Instantiate(obj, this.transform);
            cloneObj.transform.localPosition = new Vector3(xOffset + obj.transform.localPosition.x, i / 10 + obj.transform.localPosition.y, zOffset + obj.transform.localPosition.z);

            clonedPagesList.Add(cloneObj);
        }
    }
}
