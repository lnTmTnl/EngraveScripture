using UnityEngine;
using UnityEngine.UI;


namespace Framework.CharacterWriter
{

    public class Draw : MonoBehaviour
    {
        //预设
        [SerializeField]
        private RawImage rawImage;
        [SerializeField]
        private GameObject paperQuad;
        [SerializeField]
        private Material brushMat;
        [SerializeField]
        private Material clearMat;
        [SerializeField]
        private Texture selectedContent;
        [SerializeField]
        private Texture xuanzhiTex;
        [SerializeField]
        private Texture paperedPearTex;
        [SerializeField]
        private Texture rubbedPaperPearTex;
        [SerializeField]
        private Texture oiledPaperPearTex;
        [SerializeField]
        private Texture carvedPearTex;
        [SerializeField]
        private Texture inkedPearTex;

        //传入
        private Camera m_uiCamera;
        private RenderMode m_renderMode;

        private float m_rawImageSizeX;
        private float m_rawImageSizeY;
        private Vector3 m_mousePos;
        private Vector3 m_lastMousePos;
        public RenderTexture rt;

        public static RenderTexture m_renderTex { get; private set; }
        public static RenderTexture PearDrawnRenderTex { get; private set; }
        public static RenderTexture RubbedPearDrawnRenderTex { get; private set; }
        public static RenderTexture OiledPearDrawnRenderTex { get; private set; }
        public static RenderTexture CarvedPearDrawnRenderTex { get; private set; }
        public static RenderTexture InkedPearDrawnRenderTex { get; private set; }


        public void Init(Canvas canvas, Camera uiCamera)
        {
            m_uiCamera = uiCamera;
            m_renderMode = canvas.renderMode;

            m_rawImageSizeX = rawImage.GetComponent<RectTransform>().sizeDelta.x;
            m_rawImageSizeY = rawImage.GetComponent<RectTransform>().sizeDelta.y;

            m_renderTex = RenderTexture.GetTemporary(512, 512);
            Graphics.Blit(xuanzhiTex, m_renderTex);

            PearDrawnRenderTex = RenderTexture.GetTemporary(512, 512);
            Graphics.Blit(paperedPearTex, PearDrawnRenderTex);

            RubbedPearDrawnRenderTex = RenderTexture.GetTemporary(512, 512);
            Graphics.Blit(rubbedPaperPearTex, RubbedPearDrawnRenderTex);

            OiledPearDrawnRenderTex = RenderTexture.GetTemporary(512, 512);
            Graphics.Blit(oiledPaperPearTex, OiledPearDrawnRenderTex);

            CarvedPearDrawnRenderTex = RenderTexture.GetTemporary(512, 512);
            Graphics.Blit(carvedPearTex, CarvedPearDrawnRenderTex);

            InkedPearDrawnRenderTex = RenderTexture.GetTemporary(512, 512);
            Graphics.Blit(inkedPearTex, InkedPearDrawnRenderTex);

            rawImage.texture = m_renderTex;
            paperQuad.GetComponent<MeshRenderer>().material.mainTexture = m_renderTex;

            brushMat.SetColor("_Color", Color.black);
            brushMat.SetFloat("_Size", 100);
        }

        public void Release()
        {
            if (m_renderTex != null) m_renderTex.Release();
            if (PearDrawnRenderTex != null) PearDrawnRenderTex.Release();
            if (RubbedPearDrawnRenderTex != null) RubbedPearDrawnRenderTex.Release();
            if (OiledPearDrawnRenderTex != null) OiledPearDrawnRenderTex.Release();
            if (CarvedPearDrawnRenderTex != null) CarvedPearDrawnRenderTex.Release();
            if (InkedPearDrawnRenderTex != null) InkedPearDrawnRenderTex.Release();
        }

        public void SetProperty(Color brushColor, int size)
        {
            brushMat.SetColor("_Color", brushColor);
            brushMat.SetFloat("_Size", size);
        }
        public void SetProperty(Color brushColor)
        {
            brushMat.SetColor("_Color", brushColor);
        }
        public void SetProperty(int size)
        {
            brushMat.SetFloat("_Size", size);
        }

        public void Clear()
        {
            Graphics.Blit(xuanzhiTex, m_renderTex, clearMat);
            Graphics.Blit(xuanzhiTex, m_renderTex);

            Graphics.Blit(paperedPearTex, PearDrawnRenderTex, clearMat);
            Graphics.Blit(paperedPearTex, PearDrawnRenderTex);

            Graphics.Blit(rubbedPaperPearTex, RubbedPearDrawnRenderTex, clearMat);
            Graphics.Blit(rubbedPaperPearTex, RubbedPearDrawnRenderTex);

            Graphics.Blit(oiledPaperPearTex, OiledPearDrawnRenderTex, clearMat);
            Graphics.Blit(oiledPaperPearTex, OiledPearDrawnRenderTex);

            Graphics.Blit(carvedPearTex, CarvedPearDrawnRenderTex, clearMat);
            Graphics.Blit(carvedPearTex, CarvedPearDrawnRenderTex);

            Graphics.Blit(inkedPearTex, InkedPearDrawnRenderTex, clearMat);
            Graphics.Blit(inkedPearTex, InkedPearDrawnRenderTex);
            //PearDrawnRenderTex = RenderTexture.GetTemporary(512, 512);
        }

        public void StartWrite(Vector3 pos)
        {
            m_mousePos = pos;
            m_lastMousePos = pos;
        }

        public void Writing(Vector3 pos)
        {
            m_mousePos = pos;
            Paint();
            m_lastMousePos = pos;
        }

        void Paint()
        {
            var uv = GetUV(m_mousePos);
            var last = GetUV(m_lastMousePos);

            SetProperty(new Color(0, 0, 0, 1));
            brushMat.SetTexture("_Tex", m_renderTex);
            brushMat.SetVector("_UV", uv);
            brushMat.SetVector("_LastUV", last);
            Graphics.Blit(m_renderTex, m_renderTex, brushMat);

            SetProperty(new Color(0, 0, 0, 0.1f));
            brushMat.SetTexture("_Tex", PearDrawnRenderTex);
            brushMat.SetVector("_UV", uv);
            brushMat.SetVector("_LastUV", last);
            Graphics.Blit(PearDrawnRenderTex, PearDrawnRenderTex, brushMat);

            SetProperty(new Color(0, 0, 0, 0.3f));
            brushMat.SetTexture("_Tex", RubbedPearDrawnRenderTex);
            brushMat.SetVector("_UV", uv);
            brushMat.SetVector("_LastUV", last);
            Graphics.Blit(RubbedPearDrawnRenderTex, RubbedPearDrawnRenderTex, brushMat);

            SetProperty(new Color(0, 0, 0, 1f));
            brushMat.SetTexture("_Tex", OiledPearDrawnRenderTex);
            brushMat.SetVector("_UV", uv);
            brushMat.SetVector("_LastUV", last);
            Graphics.Blit(OiledPearDrawnRenderTex, OiledPearDrawnRenderTex, brushMat);

            SetProperty(new Color(0, 0, 0, 1f));
            brushMat.SetTexture("_Tex", CarvedPearDrawnRenderTex);
            brushMat.SetVector("_UV", uv);
            brushMat.SetVector("_LastUV", last);
            Graphics.Blit(selectedContent, CarvedPearDrawnRenderTex);

            SetProperty(new Color(0, 0, 0, 1f));
            Graphics.Blit(selectedContent, InkedPearDrawnRenderTex);

            rt = InkedPearDrawnRenderTex;

            /*brushMat.SetTexture("_Tex2", emptyTex);
            brushMat.SetVector("_UV2", uv);
            brushMat.SetVector("_LastUV2", last);
            Graphics.Blit(PearDrawnRenderTex, PearDrawnRenderTex, brushMat);*/
        }

        Vector2 GetUV(Vector2 brushPos)
        {
            //获取图片在屏幕中的像素位置
            Vector2 rawImagePos = Vector2.zero;

            //判断所在画布的渲染方式，不同渲染方式的位置计算方式不同
            switch (m_renderMode)
            {
                case RenderMode.ScreenSpaceOverlay:
                    rawImagePos = rawImage.rectTransform.position;
                    break;
                default:
                    rawImagePos = m_uiCamera.WorldToScreenPoint(rawImage.rectTransform.position);
                    break;
            }

            //换算鼠标在图片中心点的像素位置
            Vector2 pos = brushPos - rawImagePos;

            //换算鼠标在图片中UV坐标
            Vector2 uv = new Vector2(pos.x / m_rawImageSizeX + 0.5f, pos.y / m_rawImageSizeY + 0.5f);

            return uv;
        }
    }
}