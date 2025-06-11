using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BaseColorPicker : MonoBehaviour, IPointerClickHandler, IDragHandler
{
    private Image image;
    private RectTransform rt;

    public Color baseColor;
    public event Action<Color> OnColorChanged;   

    private void Awake()
    {
        image = GetComponent<Image>();
        rt = GetComponent<RectTransform>();
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

        Texture2D tex = image.mainTexture as Texture2D;
        Rect rect = rt.rect;

        float x = (localCursor.x - rect.x) / rect.width;
        float y = (localCursor.y - rect.y) / rect.height;

        int texX = Mathf.FloorToInt(x * tex.width);
        int texY = Mathf.FloorToInt(y * tex.height);

        baseColor = tex.GetPixel(texX, texY);
        if (baseColor == null) return;

        OnColorChanged?.Invoke(baseColor);
    }

}
