using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ColorPallet : MonoBehaviour, IPointerClickHandler, IDragHandler
{
    [SerializeField] private Image image;
    [SerializeField] private RectTransform rt;
    [SerializeField] private MeshRenderer meshRenderer;
    [SerializeField] private BaseColorPicker colorPicker;
    private Color color;

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
        image.color = color;
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
        if (eventData == null) return;

        if (!RectTransformUtility.ScreenPointToLocalPointInRectangle(rt, eventData.position, eventData.pressEventCamera, out localCursor))
            return;

        Texture2D tex = image.mainTexture as Texture2D;
        Rect rect = rt.rect;

        float x = (localCursor.x - rect.x) / rect.width;
        float y = (localCursor.y - rect.y) / rect.height;

        int texX = Mathf.FloorToInt(x * tex.width);
        int texY = Mathf.FloorToInt(y * tex.height);

        color = tex.GetPixel(texX, texY) * image.color;

        if (color == null) return;

        meshRenderer.material.SetColor("_BaseColor", color);
        colorPreview.color = color;
    }
}
