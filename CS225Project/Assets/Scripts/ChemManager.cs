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

    private void Awake() { instance = this; }


    public GameObject CalculateRecipe(elementType ele1, elementType ele2)
    {
        Debug.Log("Calculating Recipe");
        foreach (GameObject x in cookBook)
        {
            Debug.Log("Checking if items match recipe for " + x);
            ElementBehaviour bookElement = x.GetComponentInChildren<ElementBehaviour>();

            Debug.Log("ingredient 1 of " + x + " is " + bookElement.ingredient1);
            Debug.Log("ingredient 2 of " + x + " is " + bookElement.ingredient2);

            if ((ele1 == bookElement.ingredient1 && ele2 == bookElement.ingredient2) || (ele1 == bookElement.ingredient2 && ele2 == bookElement.ingredient1))
            {
                Debug.Log("Recipe match found");
                //return cookBook[1];
                return x;
            }
        }
        Debug.Log("Recipe Match Not Found");
        return null;
    }
}
