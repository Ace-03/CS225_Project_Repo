using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementPoolBehavior : MonoBehaviour
{
    public GameObject baseElementPrefab;
    private GameObject newBaseElement;

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // set the object to the postion of the mouse
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            // makes the base element depeing on the pool and grabes the object manager
            newBaseElement = Instantiate(baseElementPrefab, mousePos, Quaternion.identity);
            newBaseElement.GetComponent<ObjectManager>().OnMouseDown();
        }
    }

    private void OnMouseUp()
    {
        // grabes the objcet manager 
        newBaseElement.GetComponent<ObjectManager>().OnMouseUp();
    }
}
