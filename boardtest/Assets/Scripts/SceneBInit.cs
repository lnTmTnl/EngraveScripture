using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneBInit : MonoBehaviour
{
    public RenderTexture CarvedPearDrawnRenderTex;
    public RenderTexture InkedPearDrawnRenderTex;
    private void Awake()
    {
        //��SceneMgr�ж�ȡ����
       /* Dictionary<string, object> param = SceneMgr.ins.ReadSceneData();
        //��������
        //...
        CarvedPearDrawnRenderTex = param["CarvedPearDrawnRenderTex"] as RenderTexture;
        InkedPearDrawnRenderTex = param["InkedPearDrawnRenderTex"] as RenderTexture; */
    }
}