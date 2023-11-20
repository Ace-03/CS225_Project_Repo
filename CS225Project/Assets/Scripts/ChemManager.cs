//Hold all info for recipies and elements
//CalculateRecipe() which takes two element type object. It will compare those elements
// with all possible recipe combinations. If the two arguments exist as a recipe then return the 
// product of that recipe otherwise return null.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ElementBehaviour;

public class ChemManager : MonoBehaviour
{
    public GameObject[] cookBook;
    public static ChemManager instance;

    // make an instance of this script
    private void Awake() { instance = this; }

    // Function used to determine if two objects are able to create a new element
    public GameObject CalculateRecipe(elementType ele1, elementType ele2)
    {
        // check the ingredients for every element in the cook book.
        foreach (GameObject x in cookBook)
        {
            // Get the elementbehavior script from our current element from the cookbook
            ElementBehaviour bookElement = x.GetComponentInChildren<ElementBehaviour>();

            // if the our two objects are the same as the ingredients in our recip return our cookbook object
            if ((ele1 == bookElement.ingredient1 && ele2 == bookElement.ingredient2) || (ele1 == bookElement.ingredient2 && ele2 == bookElement.ingredient1))
            {
                return x;
            }
        }
        // if none of the recipes for any of the objects match then return nothing
        return null;
    }
}
