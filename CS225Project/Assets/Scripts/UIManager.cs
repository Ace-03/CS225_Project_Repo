using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ElementBehaviour;

public class UIManager : MonoBehaviour
{

    public GameObject title;
    public GameObject pachinkoButton;

    // when game start remove start button and title and create base elements
    public void OnStartGame()
    {
        title.SetActive(false);
        pachinkoButton.SetActive(true);
    }
}
