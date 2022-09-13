using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Write : MonoBehaviour
{
    [SerializeField]
    private GameObject paper;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<RawImage>().material.SetTexture("_UpperTexture2D", Textures.Pages[0]);
        paper.GetComponent<MeshRenderer>().material = gameObject.GetComponent<RawImage>().material;
        GlobalFunctions.BakeTexture(gameObject.GetComponent<RawImage>().material);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
