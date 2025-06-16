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
        curRenderTexture = new RenderTexture(artImage.width, artImage.height, 0);
        curRenderTexture.Create();

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
            varietyScore = 100,
            timeTaken = artTimeTaken
        };

        isDrawing = false;
        artTimeTaken = 0;

        PriceCalculator.CalculatePrice(artData);

        CanvasReset();
    }
}
