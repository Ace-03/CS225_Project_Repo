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
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            newBaseElement = Instantiate(baseElementPrefab, mousePos, Quaternion.identity);
            newBaseElement.GetComponent<ObjectManager>().OnMouseDown();
        }
    }

    private void OnMouseUp()
    {
        newBaseElement.GetComponent<ObjectManager>().OnMouseUp();
    }
}
