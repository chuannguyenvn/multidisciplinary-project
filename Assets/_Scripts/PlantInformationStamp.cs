using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlantInformationStamp : MonoBehaviour
{
    [SerializeField] private Image _icon;
    [SerializeField] private Image _background;
    [SerializeField] private TMP_Text _informationText;

    public void OnSetData(string data)
    {
        _informationText.text = data;
    }
    public void OnClickShowInfoPanel()
    {

    }
}
