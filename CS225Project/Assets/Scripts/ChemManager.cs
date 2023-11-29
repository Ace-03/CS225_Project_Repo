// Hold all info for recipies and elements
// CalculateRecipe() is the main functionality of this script
// it will take two element types and compare them to find a matching recipe
// if a recipe exists it will send the object that has that recipe
// if there is not match it will return null
// This script should be present anywhere that chemistry is happening

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
        GameManager.instance.reactionAttempts++;

        // check the ingredients for every element in the cook book.
        foreach (GameObject x in cookBook)
        {
            // Get the elementbehavior script from our current element from the cookbook
            ElementBehaviour bookElement = x.GetComponentInChildren<ElementBehaviour>();

            // if the our two objects are the same as the ingredients in our recip return our cookbook object
            if ((ele1 == bookElement.ingredient1 && ele2 == bookElement.ingredient2) || (ele1 == bookElement.ingredient2 && ele2 == bookElement.ingredient1))
            {
                // if we're playing pachinko record this reaction.
                if (PachinkoManager.instance != null)
                {
                    PachinkoManager.instance.numOfReactions++;
                    PachinkoManager.instance.marblesInGame--;
                }
                // record this reaction in the gamemanager.
                GameManager.instance.numOfReactions++;

                
                return x;
            }
        }
        // if none of the recipes for any of the objects match then return nothing
        GameManager.instance.failedReactions++;
        return null;
    }
}
