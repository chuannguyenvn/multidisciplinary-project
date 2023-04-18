using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonPressed : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private bool buttonPressed;
    [SerializeField]
    private PlantEditManager _editManager = null;

    void Update()
    {
        if (buttonPressed)
        {
            Debug.LogError("check");
            _editManager.SaveImage();
        }
    }
    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        buttonPressed = true;
    }
    void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
    {
        buttonPressed = false;
    }
}
