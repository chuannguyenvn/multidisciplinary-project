using System;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Visuals;

public class BarUnit : MonoBehaviour
{
    [SerializeField] private RectTransform frontImageRectTransform;
    [SerializeField] private RectTransform backImageRectTransform;
    private Image frontImage;
    private Image backImage;

    private void Awake()
    {
        frontImage = frontImageRectTransform.GetComponent<Image>();
        backImage = backImageRectTransform.GetComponent<Image>();
    }

    public void SetPercentage(float percentage)
    {
        frontImageRectTransform.sizeDelta = new Vector2(frontImageRectTransform.sizeDelta.x,
            backImageRectTransform.rect.height * percentage);
    }

    public void HistoryChangedHandler(HistoryType historyType)
    {
        switch (historyType)
        {
            case HistoryType.Light:
                frontImage.color = VisualManager.Instance.GetColor(ColorType.LightPrimary);
                backImage.color = VisualManager.Instance.GetColor(ColorType.LightSecondary);
                break;
            case HistoryType.Temperature:
                frontImage.color = VisualManager.Instance.GetColor(ColorType.TemperaturePrimary);
                backImage.color = VisualManager.Instance.GetColor(ColorType.TemperatureSecondary);
                break;
            case HistoryType.Humidity:
                frontImage.color = VisualManager.Instance.GetColor(ColorType.HumidityPrimary);
                backImage.color = VisualManager.Instance.GetColor(ColorType.HumiditySecondary);
                break;
        }
    }
}