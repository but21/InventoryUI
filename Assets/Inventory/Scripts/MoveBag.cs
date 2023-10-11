using System;
using System.Collections;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using UnityEngine;

public class MoveBag : MonoBehaviour, IDragHandler
{
    public Canvas canvas;
    private RectTransform _currentRect;

    private void Awake()
    {
        _currentRect = GetComponent<RectTransform>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        _currentRect.anchoredPosition += eventData.delta;
    }
}