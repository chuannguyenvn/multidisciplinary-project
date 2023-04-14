using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlantEditManager : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField _name = null;
    [SerializeField]
    private Image _img = null;
    private void Start()
    {
        _img.enabled = false;
        _name.interactable = false;
    }
    public void OnClickRenameBtn()
    {
        _img.enabled = true;
        _name.interactable = true;
    }
    public void OnUnActiveInputName()
    {
        _name.interactable = false;
        _img.enabled = false;
    }
    public void OnClickSaveRecog()
    {

    }
    public void OnClickRetakeBtn()
    {

    }
    public void OnClickChangeRules()
    {

    }
    public void OnClickExportLog()
    {

    }
    public void OnClickRemoveBtn()
    {

    }

}
