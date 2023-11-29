// This Script will manage general game behavior that is not specific to any scene or element.
// It will do things like incriment data such as reaction attemts or a play timer and other such statistics.
// This script will also handle File IO and Scene Management.
// The script will be made persistent so that it does not unload between scenes.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static ElementBehaviour;

public class GameManager : MonoBehaviour
{
    private float playTime;
    private bool oldDataLoaded = false;

    public int numOfReactions;
    public int reactionAttempts;
    public int FailedReactions;
    public int pachinkoScore;

    public GameObject fire;
    public GameObject water;
    public GameObject earth;
    public static GameManager instance;


    class GameStats
    {
        public float totalPlayTime;
        public int totalReactions;
        public int totalReactionAttempts;
        public int totalFailedReactions;
        public int pachinkoHighScore;
    }



    void Awake()
    {
        // if there is a static instance of the gamemanager and it isn't this set this object false
        // otherwise make this the instance and set it not to destroy on loading new scenes
        if (instance != null && instance != this)
            gameObject.SetActive(false);
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        // if we haven't loaded our json file's data then do so
        if (!oldDataLoaded)
        {
            ReadJsonFile();
            oldDataLoaded = true;
        }
    }



    private void Update()
    {
        // increment playtime every frame
        playTime += Time.deltaTime;
    }

    // creates new fire, water, or earth object 

    public void OnHomeScene()
    {
        // load the home scene
        SceneManager.LoadScene(0);
    }

    public void OnPachinkoScene()
    {
        // load the pachinko scene
        SceneManager.LoadScene("Pachinko");
    }

    // save our data to the json when the game closes
    void OnApplicationQuit()
    {
        SaveToJsonFile();
    }

    // the two functions below were heavily borrowed from a powerpoint
    // this was from SIM 251 and the slides were created by professor Slease
    // the powerpoint will be included in the Github
    void SaveToJsonFile()
    {
        // create temp gameObject
        GameStats newGameStats = new GameStats();

        // set values
        newGameStats.totalPlayTime = playTime;
        newGameStats.totalReactions = numOfReactions;
        newGameStats.totalReactionAttempts = reactionAttempts;
        newGameStats.totalFailedReactions = FailedReactions;
        newGameStats.pachinkoHighScore = pachinkoScore;

        // write values to json
        string json = JsonUtility.ToJson(newGameStats, true);
        Debug.Log(json);
        Debug.Log(Application.persistentDataPath + "/GameStatsSaved.json");
        System.IO.File.WriteAllText(Application.persistentDataPath + "/GameStatsSaved.json", json);
    }

    void ReadJsonFile()
    {
        // dont read the file if it doesn't exist
        if (Application.persistentDataPath + "/GameStatsSaved.json" != null)
        {
            // create string and read data from file onto it
            string json = System.IO.File.ReadAllText(Application.persistentDataPath + "/GameStatsSaved.json");
            // create temp gamestats object and convert string to gamestats and set stat values.
            GameStats oldGameStats = JsonUtility.FromJson<GameStats>(json);
            playTime = oldGameStats.totalPlayTime;
            numOfReactions = oldGameStats.totalReactions;
            reactionAttempts = oldGameStats.totalReactionAttempts;
            FailedReactions = oldGameStats.totalFailedReactions;
            pachinkoScore = oldGameStats.pachinkoHighScore;
        }

    }

}
