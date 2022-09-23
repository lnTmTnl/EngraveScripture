using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionController : MonoBehaviour
{
    public Dictionary<Steps, List<Question>> StepToQuestionDict { get; set; }
    public List<List<int>> SelectedAnswers { get; set; }
    [SerializeField]
    private ToggleGroup selectionGroup;
    [SerializeField]
    private Toggle selectionToggle;
    [SerializeField]
    private Text questionContentText;
    private int currentQuestionIndex;
    private List<Toggle> selectionToggles;
    private bool isSubmited;

    // Start is called before the first frame update
    void Start()
    {
        currentQuestionIndex = -1;
        isSubmited = false;
        selectionToggles = new List<Toggle>();
        StepToQuestionDict = new Dictionary<Steps, List<Question>>();
        SelectedAnswers = new List<List<int>>();

        List<Question> writingQuestion = new List<Question>
        {
            new Question("印刷使用的宣纸是生宣纸还是熟宣纸？", new List<string>{ "生宣纸", "熟宣纸" }, new List<int>{ 1 }),
            new Question("宋代时期，写样的字体大概有哪三种？", new List<string>{ "赵体字", "欧体字", "颜体字", "柳体字" }, new List<int>{ 1, 2, 3 })
        };
        StepToQuestionDict.Add(Steps.Writing, writingQuestion);

        List<Question> selectingQuestions = new List<Question> {
            //new Question("为什么选择质地坚硬的木材作为雕版印刷的材料？", "质地坚硬不易破裂，方便再次刻板。"),
            new Question("中国古代，一般选用_____与_____作为雕版用料。", new List<string>{ "梨木", "樟木", "枣木", "桃木" }, new List<int>{ 0, 2 }),
            //new Question("正是因为中国古代经常使用梨木、枣木作为雕版的材料，因此 ________成为雕版印刷的代名词。", "付之梨枣")
        };
        StepToQuestionDict.Add(Steps.Selecting, selectingQuestions);

        ToggleQuestion(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleQuestion(int direction)
    {
        if (direction == 0 && currentQuestionIndex == -1)
        {
            currentQuestionIndex++;
            DisplayQuestion();
            return;
        }
        if (!isSubmited)
        {
            JudgeAnswers();
            SelectedAnswers[currentQuestionIndex].Clear();
            foreach (int item in StepToQuestionDict[States.currentStep][currentQuestionIndex].AnswerSelections)
            {
                SelectedAnswers[currentQuestionIndex].Add(item);
            }
            isSubmited = true;
        }
        else if (currentQuestionIndex + direction >= 0 && currentQuestionIndex + direction < StepToQuestionDict[States.currentStep].Count)
        {
            currentQuestionIndex += direction;
            DisplayQuestion();
            isSubmited = false;
        }
        /*if (direction == 0 && currentQuestionIndex == -1)
        {
            currentQuestionIndex++;
            DisplayQuestion();
        }
        else if(currentQuestionIndex + direction >= 0 && currentQuestionIndex + direction < StepToQuestionDict[States.currentStep].Count)
        {
            currentQuestionIndex += direction;
            DisplayQuestion();
        }*/
    }

    void DisplayQuestion()
    {
        if(SelectedAnswers.Count <= currentQuestionIndex)
        {
            SelectedAnswers.Add(new List<int>());
        }
        questionContentText.text = StepToQuestionDict[States.currentStep][currentQuestionIndex].Content;
        for(int i = 0; i < selectionToggles.Count; i++)
        {
            Destroy(selectionToggles[i].gameObject);
        }
        selectionToggles.Clear();

        for (int i = 0; i < StepToQuestionDict[States.currentStep][currentQuestionIndex].Selections.Count; i++)
        {
            Toggle newSelection = Instantiate(selectionToggle);
            selectionToggles.Add(newSelection);
            newSelection.transform.Find("Label").GetComponent<Text>().text = StepToQuestionDict[States.currentStep][currentQuestionIndex].Selections[i];
            newSelection.GetComponent<SelectionController>().Id = i;
            newSelection.GetComponent<SelectionController>().SelectedAnswers = SelectedAnswers[currentQuestionIndex];
            newSelection.transform.SetParent(selectionGroup.transform);
        }
    }

    void JudgeAnswers()
    {
        bool result = true;
        List<int> currentAnswers = SelectedAnswers[currentQuestionIndex];
        List<int> correctAnswers = StepToQuestionDict[States.currentStep][currentQuestionIndex].AnswerSelections;
        foreach(int item in currentAnswers)
        {
            if (!correctAnswers.Contains(item))
            {
                result = false;
                break;
            }
        }
        if(currentAnswers.Count != correctAnswers.Count)
        {
            result = false;
        }
        if (result)
        {
            Debug.Log(1);
        }
        else
        {
            Debug.Log(0);
        }
    }
}
