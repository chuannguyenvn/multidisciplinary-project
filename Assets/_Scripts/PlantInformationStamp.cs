using System;
using System.Collections;
using System.Collections.Generic;
using Adafruit;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlantInformationStamp : MonoBehaviour
{
    [SerializeField] private HistoryType _historyType;
    [SerializeField] private DataReceiver _dataReceiver;
    
    [SerializeField] private Image _icon;
    [SerializeField] private Image _background;
    [SerializeField] private TMP_Text _informationText;

    private void Start()
    {
        _dataReceiver.SetTopic(_historyType);
        _dataReceiver.OnMessageReceived += OnSetData;
    }

    public void OnSetData(string data)
    {
        var value = data.Split(';')[2];
        _informationText.text = value;
    }
}
