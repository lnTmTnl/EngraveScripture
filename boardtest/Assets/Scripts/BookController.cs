using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookController : MonoBehaviour
{
    [SerializeField]
    private GameObject paperLeft;
    [SerializeField]
    private GameObject paperRight;
    [SerializeField]
    private GameObject paperBackLeft;
    [SerializeField]
    private GameObject paperBackRight;
    [SerializeField]
    private GameObject ProtectorPaperTop;
    [SerializeField]
    private GameObject CoverTop;
    [SerializeField]
    private GameObject Line;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PunchHole()
    {
        if(States.currentStep == Steps.Punching)
        {
            paperLeft.GetComponent<MeshRenderer>().material.SetFloat("_hideAlphaMask", 0);
            paperRight.GetComponent<MeshRenderer>().material.SetFloat("_hideAlphaMask", 0);
            paperBackLeft.GetComponent<MeshRenderer>().material.SetFloat("_hideAlphaMask", 0);
            paperBackRight.GetComponent<MeshRenderer>().material.SetFloat("_hideAlphaMask", 0);
            ProtectorPaperTop.GetComponent<MeshRenderer>().material.SetFloat("_hideAlphaMask", 0);
            CoverTop.GetComponent<MeshRenderer>().material.SetFloat("_hideAlphaMask", 0);

            States.currentStep = Steps.Lining;
        }
        else if(States.currentStep == Steps.Lining)
        {
            Line.SetActive(true);
            States.currentStep = Steps.Finished;
        }
    }
}
