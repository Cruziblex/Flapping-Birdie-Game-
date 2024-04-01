using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MainMenuLogic : MonoBehaviour
{
    public GameObject parentSkin;
    private int highScore;
    public TextMeshProUGUI highScoreText;

    // Start is called before the first frame update
    void Start()
    {
        highScore= PlayerPrefs.GetInt("HighScore", 0);
        unlockSkins();
        highScoreText.text = "Current High Score: " + highScore;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void unlockSkins()
    {
        if (highScore >= 10)
        {
            parentSkin.transform.GetChild(1).gameObject.GetComponent<Button>().interactable = true;
        }
        if (highScore >= 25)
        {
            parentSkin.transform.GetChild(2).gameObject.GetComponent<Button>().interactable = true;
        }
        if (highScore >= 50)
        {
            parentSkin.transform.GetChild(3).gameObject.GetComponent<Button>().interactable = true;
        }
        if (highScore >= 100)
        {
            parentSkin.transform.GetChild(4).gameObject.GetComponent<Button>().interactable = true;
        }
    }
}
