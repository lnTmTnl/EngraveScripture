using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneBInit : MonoBehaviour
{
    public RenderTexture CarvedPearDrawnRenderTex;
    public RenderTexture InkedPearDrawnRenderTex;
    private void Awake()
    {
        //从SceneMgr中读取数据
       /* Dictionary<string, object> param = SceneMgr.ins.ReadSceneData();
        //其他函数
        //...
        CarvedPearDrawnRenderTex = param["CarvedPearDrawnRenderTex"] as RenderTexture;
        InkedPearDrawnRenderTex = param["InkedPearDrawnRenderTex"] as RenderTexture; */
    }
}