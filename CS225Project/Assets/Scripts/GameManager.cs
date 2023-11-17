// This Script will manage the gamehaviour outside of the chemistry system
// It will do things like incriment data such as reaction attemts or a play timer and other such statistics.
// If we decide to limit the number of objects or copies of objects this script will handle that.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ElementBehaviour;

public class GameManager : MonoBehaviour
{
    public GameObject fire;
    public GameObject water;
    public GameObject earth;
    
    public GameObject makeElement(elementType elem)
    {
        Debug.Log("Tried to create element");
        switch (elem) {
        case elementType.fire:
            return Instantiate(fire.gameObject);
            //break;     
        case elementType.water:
            return Instantiate(water.gameObject);
            //break;
        case elementType.earth:
            return Instantiate(earth.gameObject);
            //break;
        }
        return null;
        
    }
}
