// used this video to learn drag and drop 
//https://youtu.be/BGr-7GZJNXg?si=ZjK38vO2-PfA4fUS

//user controls 
//click and drag freatures 


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ObjectManager : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private Canvas canvas;

    private RectTransform rectTransform;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>(); // Gets the item transformation
    }

    // Tells when the player starts to drag the item
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBegingDrag");
    }

    // Tells whwn the items is being dragged
    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("OnDrag");
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor; // moved the item based off the mouse postion and cavan size
    }

    // Tells when the Player stops dragging item
    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag");
    }

    // Tells when the cursor is pushed down
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown");
    }
}
