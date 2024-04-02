using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SkinManager : MonoBehaviour
{
    private bool SkinsAreUnlocked = false;
    private GameObject[] skin;
    int highScore;
    private int[] unlockPoints;
    public int pointGap;

    void Start()
    {
        pointGap = 20;
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        // Instantiate the skin GameObject array for use later
        skin = new GameObject[gameObject.transform.childCount];
        // Instantiate the levels needed to unlock skins according to how many skins there are
        unlockPoints = new int[gameObject.transform.childCount - 1];
        // Set skin unlock points to every 15 points
        for (int i = 0; i < unlockPoints.Length; i++)
        {
            unlockPoints[i] = pointGap;
            pointGap += 20;
        }
        // Retrieve highscore from memory

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
        for (int i = 0; i < (gameObject.transform.childCount - 1); i++)
        {
            if ((highScore >= unlockPoints[i]))
            {
                skin[i + 1].GetComponent<Button>().interactable = true;
                skin[i + 1].GetComponent<EventTrigger>().enabled = true;
                
            }
            else
            {
                skin[i + 1].GetComponent<EventTrigger>().enabled = false;
            }
            Debug.Log("This is iteration " + i + " This is the highscore saved: " + highScore + " this is what this iteration shows for unlockpoints: " + unlockPoints[i] + "This is the skin saved in this iteration: " + skin[i].name);
        }

/*
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
*/
    }

}