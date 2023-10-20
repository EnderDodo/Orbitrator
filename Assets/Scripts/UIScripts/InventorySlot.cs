using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    private RectTransform _rectTransform;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag is not null && _rectTransform.childCount == 0)
        {
            eventData.pointerDrag.GetComponent<DragDrop>().SetParentAfterDrag(_rectTransform);
        }
    }
}
