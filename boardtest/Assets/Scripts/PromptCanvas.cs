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
                StepMessageText.text = "写样";
                DetailMessage.text = "点击宣纸堆放置宣纸；点击笔架拿起毛笔，使用键盘数字键选择；用毛笔点击砚台沾墨书写。";
                break;
            case Steps.Selecting:
                StepMessageText.text = "选择木料";
                DetailMessage.text = "点击木板堆选择合适的木料。";
                break;
            case Steps.Pasting:
                StepMessageText.text = "刷浆糊";
                DetailMessage.text = "点击刷子，用键盘数字键选择；点击浆糊；点击鼠标在木板上拖动刷上一层浆糊。";
                break;
            case Steps.Flipping:
                StepMessageText.text = "反拓";
                DetailMessage.text = "点击宣纸左下角并拖动，将其盖在木板上。";
                break;
            case Steps.Pressing:
                StepMessageText.text = "压平";
                DetailMessage.text = "点击鼠标在木板上拖动将宣纸压平。";
                break;
            case Steps.Rubbing:
                StepMessageText.text = "搓去宣纸";
                DetailMessage.text = "点击木板将宣纸搓去一层。";
                break;
            case Steps.Oiling:
                StepMessageText.text = "刷油";
                DetailMessage.text = "点击鼠标在木板上拖动刷上一层油。";
                break;
            case Steps.Carving:
                StepMessageText.text = "雕刻";
                DetailMessage.text = "点击木板进行雕刻。";
                break;
            case Steps.Inking:
                StepMessageText.text = "刷墨";
                DetailMessage.text = "点击鼠标在木板上拖动刷上一层墨。";
                break;
            case Steps.Printing:
                StepMessageText.text = "印刷";
                DetailMessage.text = "点击宣纸左下角并拖动，将其盖在木板上进行印刷，然后拖动右下角揭开。";
                break;
            case Steps.Folding:
                StepMessageText.text = "拣页折页";
                DetailMessage.text = "点击书页堆进行放置，点击放置好的书页进行对折。";
                break;
            case Steps.Sorting:
                StepMessageText.text = "齐栏";
                DetailMessage.text = "点击已对折的书页堆将其整理对齐。";
                break;
            case Steps.Protector:
                StepMessageText.text = "加装护页";
                DetailMessage.text = "点击褐色的护页堆进行放置。";
                break;
            case Steps.Coverring:
                StepMessageText.text = "装书皮";
                DetailMessage.text = "点击蓝色的书皮堆进行放置。";
                break;
            case Steps.Punching:
                StepMessageText.text = "锥书眼";
                DetailMessage.text = "点击半成品书锥书眼。";
                break;
            case Steps.Lining:
                StepMessageText.text = "穿线";
                DetailMessage.text = "点击半成品书进行穿线。";
                break;
            case Steps.Finished:
                StepMessageText.text = "完成";
                DetailMessage.text = "";
                break;
        }
    }
}
