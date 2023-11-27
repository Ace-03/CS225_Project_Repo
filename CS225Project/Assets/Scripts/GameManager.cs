// This Script will manage the gamehaviour outside of the chemistry system
// It will do things like incriment data such as reaction attemts or a play timer and other such statistics.
// If we decide to limit the number of objects or copies of objects this script will handle that.

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
    public int pachinkoSessionScore;

    public GameObject fire;
    public GameObject water;
    public GameObject earth;
    public static GameManager instance;


    class GameStats
    {
        public float totalPlayTime;
        public int totalReactions;
        public int pachinkoHighScore;
    }



    void Awake()
    {
        if (instance != null && instance != this)
            gameObject.SetActive(false);
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        if (!oldDataLoaded)
        {
            ReadJsonFile();
            oldDataLoaded = true;
        }
    }




    private void Update()
    {
        playTime += Time.deltaTime;
    }

    // creates new fire, water, or earth object 
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

    public void OnHomeScene()
    {
        SceneManager.LoadScene(0);
    }

    public void OnPachinkoScene()
    {
        SceneManager.LoadScene("Pachinko");
    }

    void OnApplicationQuit()
    {
        SendInJsonFormat();
    }

    // the two functions below were heavily borrowed from this powerpoint: https://erau.instructure.com/courses/160487/files/35221192/download?download_frd=1
    // this was from SIM 251 and the slides were created by professor Slease
    void SendInJsonFormat()
    {
        // create temp gameObject
        GameStats newGameStats = new GameStats();

        // set values
        newGameStats.totalPlayTime = playTime;
        newGameStats.totalReactions = numOfReactions;
        newGameStats.pachinkoHighScore = pachinkoSessionScore;

        // write values to json
        string json = JsonUtility.ToJson(newGameStats, true);
        Debug.Log(json);
        Debug.Log(Application.persistentDataPath + "/GameStatsSaved.json");
        System.IO.File.WriteAllText(Application.persistentDataPath + "/GameStatsSaved.json", json);
    }

    void ReadJsonFile()
    {
        // create string and read data from file onto it
        string json = System.IO.File.ReadAllText(Application.persistentDataPath + "/GameStatsSaved.json");
        // create temp gamestats object, convert string to gamestats and set stat values.
        GameStats oldGameStats = JsonUtility.FromJson<GameStats>(json);
        playTime = oldGameStats.totalPlayTime;
        numOfReactions = oldGameStats.totalReactions;
        pachinkoSessionScore = oldGameStats.pachinkoHighScore;
    }

}
