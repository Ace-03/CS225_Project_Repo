using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ElementBehaviour;

public class UIManager : MonoBehaviour
{

    public GameObject title;
    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    // when game start remove start button and title and create base elements
    public void onStartGame()
    {
        this.gameObject.SetActive(false);
        title.SetActive(false);

/*        gameManager.makeElement(elementType.fire);
        gameManager.makeElement(elementType.water);
        gameManager.makeElement(elementType.earth);*/

    }
}
