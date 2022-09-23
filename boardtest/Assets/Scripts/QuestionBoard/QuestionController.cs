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
            new Question("ӡˢʹ�õ���ֽ������ֽ��������ֽ��", new List<string>{ "����ֽ", "����ֽ" }, new List<int>{ 1 }),
            new Question("�δ�ʱ�ڣ�д�����������������֣�", new List<string>{ "������", "ŷ����", "������", "������" }, new List<int>{ 1, 2, 3 })
        };
        StepToQuestionDict.Add(Steps.Writing, writingQuestion);

        List<Question> selectingQuestions = new List<Question> {
            //new Question("Ϊʲôѡ���ʵؼ�Ӳ��ľ����Ϊ���ӡˢ�Ĳ��ϣ�", "�ʵؼ�Ӳ�������ѣ������ٴο̰塣"),
            new Question("�й��Ŵ���һ��ѡ��_____��_____��Ϊ������ϡ�", new List<string>{ "��ľ", "��ľ", "��ľ", "��ľ" }, new List<int>{ 0, 2 }),
            //new Question("������Ϊ�й��Ŵ�����ʹ����ľ����ľ��Ϊ���Ĳ��ϣ���� ________��Ϊ���ӡˢ�Ĵ����ʡ�", "��֮����")
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
