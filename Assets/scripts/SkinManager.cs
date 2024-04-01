using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class SkinManager : MonoBehaviour
{
    public int childIndex;
    public MainMenuLogic menuLogic;
    private bool hasActionBeenPerformed = false;

    void Start()
    {
        childIndex = gameObject.transform.GetSiblingIndex();
        menuLogic = GameObject.FindGameObjectWithTag("Menu Logic").GetComponent<MainMenuLogic>();
    }

    private void Update()
    {
        selectCurrentSkin();
    }

    //Selects the skin name and saves it to memory
    public void saveSkin()
    {

        PlayerPrefs.SetInt("Skin Index", childIndex);

        //For Debugging
        //Debug.Log("This is what is saved: " + (PlayerPrefs.GetInt("Skin Index", 0)));

    }

    void OnDisable()
    {
        hasActionBeenPerformed = false;
    }
    public void SimulateMouseClick()
    {
        // Create a pointer event data
        PointerEventData pointerEventData = new PointerEventData(EventSystem.current);

        // Set the position of the pointer event (use the center of the current GameObject)
        pointerEventData.position = Camera.main.WorldToScreenPoint(transform.position);

        // Perform a raycast to check for objects under the pointer
        RaycastResult raycastResult = new RaycastResult();
        raycastResult.gameObject = gameObject;

        // Simulate a pointer down event
        ExecuteEvents.Execute(gameObject, pointerEventData, ExecuteEvents.pointerDownHandler);

        // Simulate a pointer click event
        ExecuteEvents.Execute(gameObject, pointerEventData, ExecuteEvents.pointerClickHandler);

        // Simulate a pointer up event
        ExecuteEvents.Execute(gameObject, pointerEventData, ExecuteEvents.pointerUpHandler);
    }

    private void selectCurrentSkin()
    {
        if (!hasActionBeenPerformed)
        {
            if (gameObject != null)
            {
                if (PlayerPrefs.GetInt("Skin Index", 0) == childIndex)
                {
                    if (isActiveAndEnabled && (gameObject.GetComponent<UnityEngine.UI.Button>().IsInteractable() == true))
                    {
                        SimulateMouseClick();
                        //Debug.Log("This should appear when object becomes active.Index is: " + childIndex);
                    }

                }


            }

            // Set the flag to indicate that the action has been performed
            hasActionBeenPerformed = true;
        }

    }  

}