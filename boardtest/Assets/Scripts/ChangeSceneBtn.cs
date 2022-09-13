using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSceneBtn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnChangeSceneBtnClick1()
    {
        States.currentStep = Steps.Inking;
        Dictionary<string, object> param = new Dictionary<string, object>();
        param.Add("CarvedPearDrawnRenderTex", Framework.CharacterWriter.Draw.CarvedPearDrawnRenderTex);
        param.Add("InkedPearDrawnRenderTex", Framework.CharacterWriter.Draw.InkedPearDrawnRenderTex);
        SceneMgr.ins.ToNewScene("module2", param);
    }
    public void OnChangeSceneBtnClick2()
    {
        SceneMgr.ins.ReadSceneData();
        //States.currentStep = Steps.Inking;
        //Dictionary<string, object> param = new Dictionary<string, object>();
        //param.Add("CarvedPearDrawnRenderTex", Framework.CharacterWriter.Draw.CarvedPearDrawnRenderTex);
        //param.Add("InkedPearDrawnRenderTex", Framework.CharacterWriter.Draw.InkedPearDrawnRenderTex);
        SceneMgr.ins.ToNewScene("module3");
    }
}
