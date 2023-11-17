// used this video to learn drag and drop 
//https://youtu.be/BGr-7GZJNXg?si=ZjK38vO2-PfA4fUS

//https://www.youtube.com/watch?v=uk_E_cGrlQc
//user controls 
//click and drag freatures 


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class ObjectManager : MonoBehaviour//, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private bool moving;

    private float startPosX;
    private float startPosY;
    private bool triggerEnabled = true;
    
    void Update()
    {
        if (moving)
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            this.gameObject.transform.localPosition = new Vector3(mousePos.x - startPosX, mousePos.y - startPosY);
            
            
            if(triggerEnabled)
            {
                GetComponent<BoxCollider2D>().enabled = false;
                GetComponent<ElementBehaviour>().isHeldObject = true;
                triggerEnabled = false;
            }

        }
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            startPosX = mousePos.x - this.transform.localPosition.x;
            startPosY = mousePos.y - this.transform.localPosition.y;

            moving = true;
        }
    }

    private void OnMouseUp()
    {
        moving = false;
        GetComponent<BoxCollider2D>().enabled = true;
        StartCoroutine(NotHeld());
        triggerEnabled = true;

    }

    IEnumerator NotHeld()
    {
        yield return new WaitForSeconds(0.06f);
        GetComponent<ElementBehaviour>().isHeldObject = false;
    }

























    /*
    [SerializeField] private Canvas canvas;

    private RectTransform rectTransform;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>(); // Gets the item transformation
    }

    // Tells when the player starts to drag the item
    public void OnBeginDrag(PointerEventData eventData)
    {
        //Debug.Log("OnBegingDrag");
    }

    // Tells whwn the items is being dragged
    public void OnDrag(PointerEventData eventData)
    {
        //Debug.Log("OnDrag");
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor; // moved the item based off the mouse postion and cavan size
    }

    // Tells when the Player stops dragging item
    public void OnEndDrag(PointerEventData eventData)
    {
        //Debug.Log("OnEndDrag");
    }

    // Tells when the cursor is pushed down
    public void OnPointerDown(PointerEventData eventData)
    {
        //Debug.Log("OnPointerDown");
    }
    */
}
