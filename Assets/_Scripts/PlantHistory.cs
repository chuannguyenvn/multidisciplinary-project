using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Visuals;
using Random = UnityEngine.Random;

public class PlantHistory : Singleton<PlantHistory>
{
    public Action<HistoryType> HistoryTypeChanged;

    public HistoryType HistoryType;

    [SerializeField] private Button hourlyButton;
    [SerializeField] private Button dailyButton;
    [SerializeField] private Image background;
    [SerializeField] private Image icon;

    [SerializeField] private List<BarUnit> BarUnits;
    [SerializeField] private Sprite lightSprite;
    [SerializeField] private Sprite temperatureSprite;
    [SerializeField] private Sprite humiditySprite;

    private void Start()
    {
        foreach (var barUnit in BarUnits)
        {
            barUnit.SetPercentage(Random.value);
            HistoryTypeChanged += barUnit.HistoryChangedHandler;
        }

        HistoryTypeChanged += HistoryTypeChangedHandler;
        
        HistoryTypeChanged?.Invoke(HistoryType);
    }

    private void OnDestroy()
    {
        foreach (var barUnit in BarUnits)
        {
            HistoryTypeChanged -= barUnit.HistoryChangedHandler;
        }
    }

    private void HistoryTypeChangedHandler(HistoryType historyType)
    {
        switch (historyType)
        {
            case HistoryType.Light:
                background.color = VisualManager.Instance.GetColor(ColorType.LightSecondary);
                icon.sprite = lightSprite;
                break;
            case HistoryType.Temperature:
                background.color = VisualManager.Instance.GetColor(ColorType.TemperatureSecondary);
                icon.sprite = temperatureSprite;
                break;
            case HistoryType.Humidity:
                background.color = VisualManager.Instance.GetColor(ColorType.HumiditySecondary);
                icon.sprite = humiditySprite;
                break;
        }
    }
}

public enum HistoryType
{
    Light,
    Temperature,
    Humidity,
}