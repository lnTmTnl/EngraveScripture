using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectionController : MonoBehaviour
{
    public int Id { get; set; }
    public List<int> SelectedAnswers { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (SelectedAnswers.Contains(Id))
        {
            gameObject.GetComponent<Toggle>().isOn = true;
        }
        else
        {
            gameObject.GetComponent<Toggle>().isOn = false;
        }
    }

    public void ChangeValue()
    {
        if (gameObject.GetComponent<Toggle>().isOn && !SelectedAnswers.Contains(Id))
        {
            SelectedAnswers.Add(Id);
        }
        else if(!gameObject.GetComponent<Toggle>().isOn)
        {
            SelectedAnswers.Remove(Id);
        }
    }
}
