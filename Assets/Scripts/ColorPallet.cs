using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ColorPallet : MonoBehaviour, IPointerClickHandler, IDragHandler
{
    [SerializeField] private RenderTexture renderTexture;
    [SerializeField] private RawImage image;
    [SerializeField] private RectTransform rt;
    [SerializeField] private MeshRenderer meshRenderer;
    [SerializeField] private BaseColorPicker colorPicker;

    [Header("UI References")]
    public Image colorPreview;
    public Slider rSlider, gSlider, bSlider, aSlider;

    private PointerEventData lastEventData;

    private void Awake()
    {
        rt = image.rectTransform;
    }

    private void OnEnable()
    {
        colorPicker.OnColorChanged += SetColor;
    }
    private void OnDisable()
    {
        colorPicker.OnColorChanged -= SetColor;
    }

    private void SetColor(Color color)
    {
        image.material.SetColor("_BaseColor", color);
        UpdateColor(lastEventData);
    }

    private void UpdateSliders(Color color)
    {
        rSlider.value = Mathf.RoundToInt(color.r * 255);
        gSlider.value = Mathf.RoundToInt(color.g * 255);
        bSlider.value = Mathf.RoundToInt(color.b * 255);
        aSlider.value = Mathf.RoundToInt(color.a * 255);        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        UpdateColor(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        UpdateColor(eventData);
    }

    private void UpdateColor(PointerEventData eventData)
    {
        Vector2 localCursor;
        if (!RectTransformUtility.ScreenPointToLocalPointInRectangle(rt, eventData.position, eventData.pressEventCamera, out localCursor))
            return;

        Rect rect = rt.rect;

        float x = (localCursor.x - rect.x) / rect.width;
        float y = (localCursor.y - rect.y) / rect.height;

        Texture2D tex = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.RGB24, false);
        RenderTexture.active = renderTexture;
        tex.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height), 0, 0);
        tex.Apply();
        RenderTexture.active = null;

        int texX = Mathf.Clamp(Mathf.FloorToInt(x * tex.width), 0, tex.width - 1);
        int texY = Mathf.Clamp(Mathf.FloorToInt(y * tex.height), 0, tex.height - 1);

        Color pickedColor = tex.GetPixel(texX, texY);

        if (pickedColor == null) return;

        meshRenderer.material.color = pickedColor;
        colorPreview.color = pickedColor;

        lastEventData = eventData;
        UpdateSliders(pickedColor);
        Destroy(tex);
    }
}
