using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PromptCanvas : MonoBehaviour
{
    [SerializeField]
    private Text StepMessageText;
    [SerializeField]
    private Text DetailMessage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (States.currentStep)
        {
            case Steps.Writing:
                StepMessageText.text = "д��";
                DetailMessage.text = "�����ֽ�ѷ�����ֽ������ʼ�����ë�ʣ�ʹ�ü������ּ�ѡ����ë�ʵ����̨մī��д��";
                break;
            case Steps.Selecting:
                StepMessageText.text = "ѡ��ľ��";
                DetailMessage.text = "���ľ���ѡ����ʵ�ľ�ϡ�";
                break;
            case Steps.Pasting:
                StepMessageText.text = "ˢ����";
                DetailMessage.text = "���ˢ�ӣ��ü������ּ�ѡ�񣻵����������������ľ�����϶�ˢ��һ�㽬����";
                break;
            case Steps.Flipping:
                StepMessageText.text = "����";
                DetailMessage.text = "�����ֽ���½ǲ��϶����������ľ���ϡ�";
                break;
            case Steps.Pressing:
                StepMessageText.text = "ѹƽ";
                DetailMessage.text = "��������ľ�����϶�����ֽѹƽ��";
                break;
            case Steps.Rubbing:
                StepMessageText.text = "��ȥ��ֽ";
                DetailMessage.text = "���ľ�彫��ֽ��ȥһ�㡣";
                break;
            case Steps.Oiling:
                StepMessageText.text = "ˢ��";
                DetailMessage.text = "��������ľ�����϶�ˢ��һ���͡�";
                break;
            case Steps.Carving:
                StepMessageText.text = "���";
                DetailMessage.text = "���ľ����е�̡�";
                break;
            case Steps.Inking:
                StepMessageText.text = "ˢī";
                DetailMessage.text = "��������ľ�����϶�ˢ��һ��ī��";
                break;
            case Steps.Printing:
                StepMessageText.text = "ӡˢ";
                DetailMessage.text = "�����ֽ���½ǲ��϶����������ľ���Ͻ���ӡˢ��Ȼ���϶����½ǽҿ���";
                break;
            case Steps.Folding:
                StepMessageText.text = "��ҳ��ҳ";
                DetailMessage.text = "�����ҳ�ѽ��з��ã�������úõ���ҳ���ж��ۡ�";
                break;
            case Steps.Sorting:
                StepMessageText.text = "����";
                DetailMessage.text = "����Ѷ��۵���ҳ�ѽ���������롣";
                break;
            case Steps.Protector:
                StepMessageText.text = "��װ��ҳ";
                DetailMessage.text = "�����ɫ�Ļ�ҳ�ѽ��з��á�";
                break;
            case Steps.Coverring:
                StepMessageText.text = "װ��Ƥ";
                DetailMessage.text = "�����ɫ����Ƥ�ѽ��з��á�";
                break;
            case Steps.Punching:
                StepMessageText.text = "׶����";
                DetailMessage.text = "������Ʒ��׶���ۡ�";
                break;
            case Steps.Lining:
                StepMessageText.text = "����";
                DetailMessage.text = "������Ʒ����д��ߡ�";
                break;
            case Steps.Finished:
                StepMessageText.text = "���";
                DetailMessage.text = "";
                break;
        }
    }
}
