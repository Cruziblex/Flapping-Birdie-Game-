using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class LogicScript : MonoBehaviour
{

    public int playerScore;
    private int highScore;
    public Text scoreText;
    public Text highScoreText;
    public GameObject GameOverScreen;
    public int skinIndexes;
    public GameObject skins;
    public string[] skinNames;
    public Animator birdAnimator;
    private AudioManager audioManager;

    public void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    void Start()
    {
        Time.timeScale = 0;

        highScore = PlayerPrefs.GetInt("HighScore", 0);
        updateHighScore();
        skinIndexes = skins.transform.childCount;
        skinNames = new string[skinIndexes];

    }

    void Update()
    {
        updateHighScore();
        setSkin();
        startGameOnSpacePress();

    }






    public void addScore(int scoreToAdd) // adds the player score 
    {
        playerScore = playerScore + scoreToAdd;
        scoreText.text = playerScore.ToString();
    }


    public void restartGame()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
    }

    public void gameOver()
    {
        Time.timeScale = 0;
        GameOverScreen.SetActive(true);
    }

    public void updateHighScore()
    {
        highScoreText.text = "High Score: " + highScore.ToString();

        //updates the highscore and save it
        if (playerScore > highScore)
        {
            highScore = playerScore;
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save();
        }
       
    }
    public void setSkin()
    {
        //Creates array of skin names to check for animation state condition
        for (int j = 0; j < skinIndexes; j++)
        {
            skinNames[j] = skins.transform.GetChild(j).name;
        }

        //Iterates though the amount of skins in the Skins Prefab
        for (int i = 0; i < skinIndexes; i++)
        {
            //If the current index matches what is saved, trigger that specific player animation
            if (PlayerPrefs.GetInt("Skin Index", i) == i)
            {
                for (int j = 0; j < skinIndexes; j++)
                {
                    if (skins.transform.GetChild(i).gameObject.name == skinNames[j])
                    {
                        birdAnimator.SetTrigger(skinNames[j]);
                    }
                }

            }

        }
    }
    public void startGameOnSpacePress()
    {
        if (Input.GetKeyDown(KeyCode.Space) && (GameObject.Find("Start Text") != null))
        {
            timeScale1();
            GameObject.Find("Start Text").SetActive(false);
            audioManager.playSoundLoop(audioManager.birdIdle);
        }

    }
    public void timeScale1()
    {
        Time.timeScale = 1;
    }
    public void timescale0()
    {
        Time.timeScale = 0;
    }
}
 