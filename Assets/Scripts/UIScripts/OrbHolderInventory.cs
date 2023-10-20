using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OrbHolderInventory : MonoBehaviour, IDropHandler
{
    private RectTransform _rectTransform;
    [SerializeField] private RectTransform orbHolderGame;
    [SerializeField] private OrbHolder orbHolderPlayer;
    private GameObject _orbUI;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        if (_rectTransform.childCount == 1)
        {
            _orbUI = Instantiate(_rectTransform.GetChild(0).gameObject, orbHolderGame);
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag is not null && eventData.pointerDrag.GetComponent<InventoryItemOrb>() is not null &&
            _rectTransform.childCount == 0)
        {
            eventData.pointerDrag.GetComponent<DragDrop>().SetParentAfterDrag(_rectTransform);
            // orbHolderPlayer.orb = eventData.pointerDrag.GetComponent<InventoryItemOrb>().GetOrb();
        }
    }

    public void OnTransformChildrenChanged()
    {
        var childCount = _rectTransform.childCount;
        // orbHolderPlayer.orb = childCount switch
        // {
        //     0 => null,
        //     1 => _rectTransform.GetChild(0).gameObject.GetComponent<InventoryItemOrb>().GetOrb(),
        //     _ => orbHolderPlayer.orb
        // };

        switch (childCount)
        {
            case 0:
                orbHolderPlayer.orb = null;
                Destroy(_orbUI);
                break;
            case 1:
                orbHolderPlayer.orb = _rectTransform.GetChild(0).gameObject.GetComponent<InventoryItemOrb>().GetOrb();
                _orbUI = Instantiate(_rectTransform.GetChild(0).gameObject, orbHolderGame);
                break;
        }
    }
}