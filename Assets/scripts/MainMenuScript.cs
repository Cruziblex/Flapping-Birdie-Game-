using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(1); //This will load scene 1, the play scene
    }
    public void CloseGame()
    {
        Application.Quit();
    }
}
