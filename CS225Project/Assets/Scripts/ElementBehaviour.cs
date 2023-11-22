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
        NULL, fire, water, earth, mud, steam, magma, energy, puddle, hill, volcano, wave, brick, oil, plant, glass, sand, stone, storm, rain, cloud
    }

    public bool isHeldObject;

    public elementType element;
    public elementType ingredient1;
    public elementType ingredient2;

    // checks if item collides with another object
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // checks if item is a element and is being held
        if (collision.gameObject.CompareTag("Element") && isHeldObject) 
        {
            // sets the element the held object is colliding with each other
            ElementBehaviour otherElement = collision.gameObject.GetComponent<ElementBehaviour>();
            GameObject productElement = ChemManager.instance.CalculateRecipe(this.element, otherElement.element);

            if (productElement != null)
            {
                // creates new element based of what ingredients are used
                Instantiate(productElement, this.transform.position, Quaternion.identity);

                // destorys used ingredients
                Destroy(otherElement.gameObject);
                Destroy(this.gameObject);
            }
            else
            {
                // does the animation for the held object
                GetComponentInChildren<Animator>().SetTrigger("EndAnimation");
                // does animation for the other object
                collision.GetComponentInChildren<Animator>().SetTrigger("EndAnimation");
                return;
            }
        }
    }
}
