using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArtController : MonoBehaviour
{
    [SerializeField] private RenderTexture artImage;
    [SerializeField] private MeshRenderer artRenderer;

    private bool isDrawing;
    private float artTimeTaken;

    private void Update()
    {
        if (isDrawing)
            artTimeTaken += Time.deltaTime;
    }

    public void CanvasReset()
    {
        RenderTexture activeRT = RenderTexture.active;
        RenderTexture.active = artImage;

        GL.Clear(true, true, Color.white);

        RenderTexture.active = activeRT;
    }    

    public void ArtSell()
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
