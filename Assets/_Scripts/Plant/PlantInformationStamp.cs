using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlantInformationStamp : MonoBehaviour
{
    public string DataType;
    [Space]
    [SerializeField] private Image _icon;
    [SerializeField] private Image _background;
    [SerializeField] private TMP_Text _informationText;
    
    
    public void OnSetData(string data)
    {
        _informationText.text = data;
        Debug.Log("aaaaaaaaaaaaaa");
    }
    public string OnGetData()
    {
        return _informationText.text;
    }
    public void OnClickShowHistoryPanel()
    {

    }
}