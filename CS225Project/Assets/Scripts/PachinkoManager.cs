using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class PachinkoManager : MonoBehaviour
{
    private int dropResult;
    private bool OnCoolDown = false;
    private float coolDownTimer;
    public bool playingPachinko;
    public int startTime;
    public float playTime;
    public int marblesInGame;
    public int numOfReactions;
    public int points;
    
    public static PachinkoManager instance;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI reactionText;
    public TextMeshProUGUI timerText;
    public GameObject resultScreen;
    public GameObject StartScreen;
    public Transform[] Spawners;

    private void Awake() { instance = this; }

    void Update()
    {
        // stop if the game isn't being played
        if (!playingPachinko)
            return;

        // count down our time
        playTime -= Time.deltaTime;

        // set timer text to current time
        if (playTime > 0)
            timerText.text = playTime.ToString("0s");

        // every 2 seconds spawn a wave of marbles
        if ((int)playTime % 2 == 0 && !OnCoolDown)
        {
            OnCoolDown = true;
            coolDownTimer = 0;
            foreach (Transform x in Spawners)
                StartCoroutine(MarbleSpawnProcedure(x));
        }

        // end game when time runs out
        if (playTime <= 0)
            EndPachinko();

        // cool down for marble spawns so they dont drop every frame
        if (OnCoolDown)
        {
            coolDownTimer += Time.deltaTime;
            if (coolDownTimer > 1.5f)
            {
                OnCoolDown = false;
            }
        }

    }

    public void StartPachinko()
    {
        // clear UI
        resultScreen.SetActive(false);
        StartScreen.SetActive(false);
        timerText.gameObject.SetActive(true);

        // set blank stats
        playTime = startTime;
        numOfReactions = 0;
        marblesInGame = 0;
        playingPachinko = true;
    }

    void EndPachinko()
    {
        playingPachinko = false;
        
        // display UI and stats
        DisplayResults();

        // send score to game manager if its the new highScore
        if (points > GameManager.instance.pachinkoScore)
            GameManager.instance.pachinkoScore = points;
    }

    void DisplayResults()
    {
        // set results screen active and update text elements
        resultScreen.SetActive(true);
        timerText.gameObject.SetActive(false);
        scoreText.text = "<b>Score:</b> " + points + "pts";
        reactionText.text = "<b>Reactions:</b> " + numOfReactions;
    }

    // spawnMarble
    // include random offset
    // include random element drop
    // increment marbles on screen
    void SpawnMarble(Transform spawner)
    {
        // roll value
        int dropRate = Random.Range(-100, 101);

        // determine drop by the value rolled
        if (dropRate >= -100 && dropRate <= 40)
            dropResult = Random.Range(0, 3); // tier 1 elements
        else if (dropRate > 40 && dropRate <= 60)
            dropResult = Random.Range(3, 9); // tier 2 elements
        else if (dropRate > 60 && dropRate <= 80)
            dropResult = Random.Range(9, 12); // tier 3 elements
        else if (dropRate > 80 && dropRate <= 90)
            dropResult = Random.Range(12, 16); // tier 4 and 5 elements
        else if (dropRate > 90 && dropRate <= 97)
            dropResult = Random.Range(16, 19); // tier 6 elements
        else if (dropRate > 97 && dropRate <= 100)
            dropResult = 19; // tier 7 element

        // create offsets
        float offSetX = Random.Range(-150, 150);
        float offSetY = Random.Range(-100, 100);

        // set offsets to vector3
        Vector3 spawnPos = new Vector3(spawner.position.x + (offSetX/70), spawner.position.y + (offSetY/70), 0);

        // instantiate marble
        Instantiate(ChemManager.instance.cookBook[dropResult], spawnPos, Quaternion.identity);

        marblesInGame++;
    }

    //  give marble a random spawn delay
    IEnumerator MarbleSpawnProcedure(Transform spawner)
    {
        int spawnTimeOffSet = Random.Range(0, 1);
        yield return new WaitForSeconds(spawnTimeOffSet);
        SpawnMarble(spawner);
    }
}
