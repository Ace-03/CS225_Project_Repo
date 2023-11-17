//on every element in game 
//OntriggerEnter2D() check if this is the held object then check if the other object is an element.
//if so then call the CalculateRecipe() function from the ChemManager sending this objects element type.
//and the other objects element type. If the CalculateRecipe() function returns Null then just return the OntriggerEnter2D() function.
//if the CalculateRecipe() function returns an element then Spawn that element, destroy the other gameobject, and destroy this object.

//Hold what type of element it is and some private data
// there will be an isHeldObject bool
// there will be a data member to determine what element this object is

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementBehaviour : MonoBehaviour
{
    public enum elementType
    {
        NULL, fire, water, earth, mud, steam, magma 
    }

    public bool isHeldObject;
    public elementType element;

    public elementType ingredient1;
    public elementType ingredient2;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Objects touched On Trigger Ran");
        Debug.Log("Is this the held object: " + isHeldObject);
        if (collision.gameObject.CompareTag("Element") && isHeldObject)
        {
            ElementBehaviour otherElement = collision.gameObject.GetComponent<ElementBehaviour>();
            //Debug.Log("This object is " + this.name);
            //Debug.Log("Combine with " + otherElement.name);
            GameObject productElement = ChemManager.instance.CalculateRecipe(this.element, otherElement.element);

            if (otherElement.element == elementType.fire)
            {
                Debug.Log("Tried to combine with fire");
            }

            if (productElement != null)
            {
                Debug.Log("Tried to create new element");
                Instantiate(productElement, this.transform.position, Quaternion.identity);
                Destroy(otherElement.gameObject);
                Destroy(this.gameObject);
            }
            else
            {
                return;
            }
        }
    }
    /*
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Objects touched");
        if (collision.gameObject.CompareTag("Element"))
        {
            ElementBehaviour otherElement = collision.gameObject.GetComponent<ElementBehaviour>();
            GameObject productElement = ChemManager.instance.CalculateRecipe(this.element, otherElement.element);
            if (productElement != null)
            {
                Instantiate(productElement, this.transform.position, Quaternion.identity);
            }
            else
            {
                return;
            }
        }
    }
    
    */
}
