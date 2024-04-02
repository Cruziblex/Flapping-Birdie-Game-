
using UnityEngine;
using UnityEngine.EventSystems;

public class SkinSaver : MonoBehaviour
{
    private int skinIndex;
    private bool skinIsSelected = false;
    
    void Start()
    {
        skinIndex = gameObject.transform.GetSiblingIndex();
    }
    private void Update()
    {
        selectCurrentSkin();
    }



    //Flags the skin to disabled for future use
    private void OnDisable()
    {
        skinIsSelected = false;
    }
    public void saveSkin()
    {
        PlayerPrefs.SetInt("Skin Index", skinIndex);

        //For Debugging
        Debug.Log("This is what is saved: " + (PlayerPrefs.GetInt("Skin Index", 0)));
    }

    //Highlights the current selected skin in memory after the skins menu is enabled
    private void selectCurrentSkin()
    {
        if (!skinIsSelected)
        {
            if (gameObject != null)
            {
                if (PlayerPrefs.GetInt("Skin Index", 0) == skinIndex)
                {
                    if (isActiveAndEnabled && (gameObject.GetComponent<UnityEngine.UI.Button>().IsInteractable() == true))
                    {
                        SimulateMouseClick();
                    }

                }
            }
            //Indicates this action has been performed so Update() won't run it again.
            skinIsSelected = true;
        }

    }

    //Simulate a mouse click at curreent GameObject
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

}