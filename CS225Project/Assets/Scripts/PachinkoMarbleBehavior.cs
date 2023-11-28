using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PachinkoMarbleBehavior : ElementBehaviour
{
    public int elementTier;
    // checks if item collides with another object
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // checks if item is a element and has lower Instance ID
        if (collision.gameObject.CompareTag("Element") && this.gameObject.GetInstanceID() > collision.gameObject.GetInstanceID()) 
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
                collision.gameObject.GetComponentInChildren<Animator>().SetTrigger("EndAnimation");
                return;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // when a marble lands in a peg hole call the score function
        if (collision.CompareTag("PegHole") && PachinkoManager.instance.playingPachinko)
            StartCoroutine(collision.GetComponent<PegHoleBehaviour>().ScoreMarble(this.gameObject));
    }
}
