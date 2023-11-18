// used this video to learn drag and drop 
//https://www.youtube.com/watch?v=uk_E_cGrlQc

//user controls 
//click and drag freatures 


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class ObjectManager : MonoBehaviour//, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public bool moving;

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

    public void OnMouseDown()
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

    public void OnMouseUp()
    {
        Debug.Log("Mouse Button Released");
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
}
