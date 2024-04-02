using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SkinManager : MonoBehaviour
{
    public int childIndex;
    public MainMenuLogic menuLogic;
    private bool SkinsAreUnlocked = false;
    private GameObject[] skin;
    int highScore;

    void Start()
    {
        // Instantiate the skin GameObject array for use later
        skin = new GameObject[gameObject.transform.childCount];
        // Retrieve highscore from memory
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        childIndex = gameObject.transform.GetSiblingIndex();
        menuLogic = GameObject.FindGameObjectWithTag("Menu Logic").GetComponent<MainMenuLogic>();
        highScore = 75;
    }

    private void Update()
    {
        populateChildrenSkins();
    }

    //Selects the skin name and saves it to memory
    public void saveSkin(int index)
    {



    }

    void OnDisable()
    {
        SkinsAreUnlocked = false;
    }


    //Iterates over the skins to populate the skins gameobject array once the skins menu becomes enabled
    private void populateChildrenSkins()
    {
        if (!SkinsAreUnlocked)
        {
            if (gameObject != null)
            {
                if (isActiveAndEnabled)
                {
                    for (int i = 0; i < gameObject.transform.childCount; i++)
                    {
                        skin[i] = transform.GetChild(i).gameObject;
                    }
                    unlockSkins();
                }
            }
            //Indicates this action has been performed so it Update() won't run it again.
            SkinsAreUnlocked = true;
        }
    }
 

    private void unlockSkins()
    {
        if (highScore >= 10)
        {
            skin[1].GetComponent<Button>().interactable = true;
            skin[1].GetComponent<EventTrigger>().enabled = true;
        }
        else
        {
            skin[1].GetComponent<EventTrigger>().enabled = false;
        }
        if (highScore >= 25)
        {
            skin[2].GetComponent<Button>().interactable = true;
            skin[2].GetComponent<EventTrigger>().enabled = true;
        }
        else
        {
            skin[2].GetComponent<EventTrigger>().enabled = false;
        }
        if (highScore >= 50)
        {
            skin[3].GetComponent<Button>().interactable = true;
            skin[3].GetComponent<EventTrigger>().enabled = true;
        }
        else
        {
            skin[3].GetComponent<EventTrigger>().enabled = false;
        }
        if (highScore >= 100)
        {
            skin[4].GetComponent<Button>().interactable = true;
            skin[4].GetComponent<EventTrigger>().enabled = true;
        }
        else
        {
            skin[4].GetComponent<EventTrigger>().enabled = false;
        }
    }

}