using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorPallet : MonoBehaviour
{
    [SerializeField] private MeshRenderer meshRenderer;

    [Header("UI References")]
    public RawImage hueRing;
    public RawImage satValBox;
    public Image colorPreview;
    public Slider rSlider, gSlider, bSlider, aSlider;

    private Color currentColor;

    void Start()
    {
        UpdateSliders(Color.white);
    }

    public void OnSliderChanged()
    {
        currentColor = new Color(
            rSlider.value / 255f,
            gSlider.value / 255f,
            bSlider.value / 255f,
            aSlider.value / 255f
        );
        UpdateUIFromColor(currentColor);
    }

    public void OnHexChanged(string hex)
    {
        if (ColorUtility.TryParseHtmlString("#" + hex, out Color newColor))
        {
            currentColor = newColor;
            UpdateSliders(newColor);
        }
    }

    void UpdateSliders(Color color)
    {
        rSlider.value = Mathf.RoundToInt(color.r * 255);
        gSlider.value = Mathf.RoundToInt(color.g * 255);
        bSlider.value = Mathf.RoundToInt(color.b * 255);
        aSlider.value = Mathf.RoundToInt(color.a * 255);

        UpdateUIFromColor(color);
    }

    void UpdateUIFromColor(Color color)
    {
        colorPreview.color = color;
        meshRenderer.materials[0].color = color; 
    }
}
