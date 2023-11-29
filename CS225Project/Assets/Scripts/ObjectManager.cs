// used this video to learn drag and drop 
//https://www.youtube.com/watch?v=uk_E_cGrlQc

//user controls 
//click and drag freatures 


using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;


public class ObjectManager : MonoBehaviour
{
    private float startPosX;
    private float startPosY;
    private bool triggerEnabled = true;

    public bool moving;

    void Update()
    {
        if (moving)
        {
            // set the object to the postion of the mouse
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            this.gameObject.transform.localPosition = new Vector3(mousePos.x - startPosX, mousePos.y - startPosY);
            
            if(triggerEnabled)
            {
                // turns off boc collider
                GetComponent<BoxCollider2D>().enabled = false;
                // sets isHledObject to true
                GetComponent<ElementBehaviour>().isHeldObject = true;

                triggerEnabled = false;
            }

        }
    }

    public void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // set the object to the postion of the mouse
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
        //when mouse is released set moving to false, enable box collider, 
        Debug.Log("Mouse Button Released");
        moving = false;
        GetComponent<BoxCollider2D>().enabled = true;

        StartCoroutine(NotHeld()); // delays the activation of the NotHeld function
        
        triggerEnabled = true; 
    }

    
    IEnumerator NotHeld()
    {
        // wait for 0.06 seconds before setting the isHeldObject flag to false
        // done to prevent flag from being set too early
        yield return new WaitForSeconds(0.06f);
        GetComponent<ElementBehaviour>().isHeldObject = false;
    }
}
