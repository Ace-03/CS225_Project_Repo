using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static ElementBehaviour;

public class UIManager : MonoBehaviour
{

    public GameObject title;
    public GameObject pachinkoButton;
    public GameObject recordsButton;

    public GameObject recordsScreen;
    public TextMeshProUGUI playTimeText;
    public TextMeshProUGUI reactionAttemptsText;
    public TextMeshProUGUI failedReactionsText;
    public TextMeshProUGUI successfulReactionsText;
    public TextMeshProUGUI pachinkoHighScoreText;

    // when game start remove start button and title and create base elements
    public void onStartGame()
    {
        title.SetActive(false);
        pachinkoButton.SetActive(true);
        recordsButton.SetActive(true);
    }
    public void OnRecords()
    {
        recordsScreen.SetActive(true);

        int minutesPlayed = (int)GameManager.instance.playTime / 60;

        playTimeText.text = "<b>Play Time: </b>" + minutesPlayed.ToString("0minutes");
        reactionAttemptsText.text = "<b>Reaction Attempts: </b>" + GameManager.instance.reactionAttempts.ToString();
        failedReactionsText.text = "<b>Failed Reactions: </b>" + GameManager.instance.failedReactions.ToString();
        successfulReactionsText.text = "<b>Successful Reactions: </b>" + GameManager.instance.numOfReactions.ToString();
        pachinkoHighScoreText.text = "<b>Pachinko HighScore: </b>" + GameManager.instance.pachinkoScore.ToString("0pts");
    }

    public void OnBack()
    {
        recordsScreen.SetActive(false);
    }
}
