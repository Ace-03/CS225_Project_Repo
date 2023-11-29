using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PegHoleBehaviour : MonoBehaviour
{
    private int bonus = 50;

    public int pointvalue;
    public GameObject pointsParticle;

    // after a delay, add to the score, create a particle effect, destroy the marble, and decrease marble count
    public IEnumerator ScoreMarble(GameObject col)
    {
        yield return new WaitForSeconds(2);
        PachinkoManager.instance.points += ((col.GetComponent<PachinkoMarbleBehavior>().elementTier * pointvalue) + (bonus^(col.GetComponent<PachinkoMarbleBehavior>().elementTier - 1)));
        Instantiate(pointsParticle, this.transform.position, Quaternion.identity);
        PachinkoManager.instance.marblesInGame--;
        Destroy(col.gameObject);
    }
}
