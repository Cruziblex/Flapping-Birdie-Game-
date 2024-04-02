using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{
    public GameObject PauseMenu;
    public bool isPaused;
    public GameObject gameOverScreen;
    private AudioManager audioManager;


    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
       PauseMenu.SetActive(false);
       isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if ((GameObject.Find("Start Text") == null))
        {
            if (Input.GetKeyDown(KeyCode.Escape))//Pause or resume game on Ecape:
            {
                if (gameOverScreen.activeSelf != true)
                {
                    if (isPaused)
                    {
                        ResumeGame();
                    }
                    else
                    {
                        PauseGame();
                    }
                }


            }
        }
        
    }

    public void PauseGame()//Pause the Game
    {
        PauseMenu.SetActive(true);
        Time.timeScale = 0;
        isPaused = true;
        audioManager.muteSfxLoop();
    }

    public void ResumeGame() // Resume The game
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1;
        isPaused = false;
        audioManager.unmuteSfxLoop();
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene(0);
    }
}
