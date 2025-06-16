using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static Unity.VisualScripting.Member;

public class ArtController : MonoBehaviour
{
    [SerializeField] private RenderTexture artImage;
    [SerializeField] private MeshRenderer artRenderer;
    [SerializeField] private Camera drawCam;

    private bool isDrawing;
    private float artTimeTaken;
    private RenderTexture curRenderTexture;

    private void Awake()
    {
        ResetCanvas();
    }

    private void ResetCanvas()
    {
        Graphics.Blit(artImage, curRenderTexture);
        artRenderer.materials[0].SetTexture("_Cam_Texture", curRenderTexture);
        drawCam.targetTexture = curRenderTexture;
    }

    private void Update()
    {
        if (isDrawing)
            artTimeTaken += Time.deltaTime;
    }
        
    public void ArtReset()
    {
        Manager.UI.PopupStart("정말 그림을 초기화 하시겠습니까?", CanvasReset);
    }

    public void ArtSell()
    {
        Manager.UI.PopupStart("정말 그림을 판매 하시겠습니까?", Sell);
    }

    private void CanvasReset()
    {
        ResetCanvas();
    }

    private void Sell()
    {
        ArtData artData = new ArtData
        {
            artName = artImage.name,
            artDescription = "",
            varietyScore = AnalyzeColorComplexity(ConvertRenderTextureToTexture2D(artImage)),
            timeTaken = artTimeTaken
        };

        isDrawing = false;
        artTimeTaken = 0;

        PriceCalculator.CalculatePrice(artData);

        CanvasReset();
    }

    private float AnalyzeColorComplexity(Texture2D texture)
    {
        HashSet<Color32> uniqueColors = new HashSet<Color32>();
        Color32[] pixels = texture.GetPixels32();

        foreach (var pixel in pixels)
        {
            if (pixel.a > 0)
                uniqueColors.Add(pixel);
        }

        return Mathf.Clamp01(uniqueColors.Count / 10000f);
    }
    private Texture2D ConvertRenderTextureToTexture2D(RenderTexture renderTexture)
    {
        RenderTexture currentRT = RenderTexture.active;

        RenderTexture.active = renderTexture;

        Texture2D tex = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.RGBA32, false);

        tex.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height), 0, 0);
        tex.Apply();

        RenderTexture.active = currentRT;

        return tex;
    }
}
