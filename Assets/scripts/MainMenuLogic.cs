using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuLogic : MonoBehaviour
{
    private int highScore;
    public TextMeshProUGUI highScoreText;
    private Toggle musicToggle;
    private Toggle sfxToggle;
    private AudioManager audioManager;
    private bool settingsAreToggled = false;
    // Start is called before the first frame update
    public void Awake()
    {

        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();


    }
    void Start()
    {
        highScore= PlayerPrefs.GetInt("HighScore", 0);
        highScoreText.text = "Current High Score: " + highScore;

    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("SettingsMenu") != null)
        {
            musicToggle = GameObject.Find("Toggle_Music").GetComponent<Toggle>();
            sfxToggle = GameObject.Find("Toggle_SFX").GetComponent<Toggle>();
            loadToggleStatus();
        }
    }

    //Saves the status of toggle to memory as 1 or 0 for true and false
    public void saveMusicToggleStatus()
    {
        if (musicToggle.isOn == true)
        {
            PlayerPrefs.SetString("musicIsOn", "True");

        }
        if (musicToggle.isOn == false)
        {
            PlayerPrefs.SetString("musicIsOn", "False");
        }
        
        Debug.Log("Music toggle is saved as: " + PlayerPrefs.GetString("musicIsOn", "Default" ));
    }

    public void saveSfxToggleStatus()
    {
        if (sfxToggle.isOn == true)
        {
            PlayerPrefs.SetString("sfxIsOn", "True");
        }
        if (sfxToggle.isOn == false)
        {
            PlayerPrefs.SetString("sfxIsOn", "False");
        }
        Debug.Log("SFX Toggle is set to : " + PlayerPrefs.GetString("sfxIsOn", "Default"));
    }

    private void loadToggleStatus()
     {
        if (!settingsAreToggled)
        {
            if (GameObject.Find("SettingsMenu") != null)
            {
                if (isActiveAndEnabled)
                {
                    if (PlayerPrefs.GetString("sfxIsOn", "Default") == "False")
                    {
                        sfxToggle.isOn = false;
                    }
                    if (PlayerPrefs.GetString("musicIsOn", "Default") == "False")
                    {
                        musicToggle.isOn = false;
                    }
                }
            }
            //Indicates this action has been performed so it Update() won't run it again.
            settingsAreToggled = true;
        }

    }

    public void playGame()
    {
        SceneManager.LoadScene(1);
    }
    public void quitGame()
    {
        Application.Quit();
    }
    public void clearAllPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
    }
}
