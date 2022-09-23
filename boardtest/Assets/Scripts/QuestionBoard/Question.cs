using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum QuestionType
{
    Filling,
    Selecting
}

public class Question
{
    public string Content { get; set; }
    public List<string> Selections { get; }
    public List<int> AnswerSelections { get; set; }

    //public string AnswerStr { get; set; }
    //public QuestionType Type { get; }

    // Start is called before the first frame update
    /*public Question(string content, string answer)
    {
        this.Content = content;
        this.AnswerStr = answer;
        this.Type = QuestionType.Filling;
    }*/

    public Question(string content, List<string> selections, List<int> answers)
    {
        this.Content = content;
        this.Selections = selections;
        this.AnswerSelections = answers;
    }
}
