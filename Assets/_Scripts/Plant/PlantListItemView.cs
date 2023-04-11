using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class PlantListItemView : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _nameText = null;
    [SerializeField]
    private Image _img = null;
    [Space]
    public PlantInformationStamp LightStamp = null;
    public PlantInformationStamp TempStamp = null;
    public PlantInformationStamp MoistureStamp = null;
    [Space]
    [SerializeField]
    private UIViewManager _uiViewManager = null;

    public void SetPlantItem(string name, string id)
    {
        PlantManager.Instance.PlantDataControllersByName[name].LightValueChanged += LightStamp.OnSetData;
        PlantManager.Instance.PlantDataControllersByName[name].TemperatureValueChanged += TempStamp.OnSetData;
        PlantManager.Instance.PlantDataControllersByName[name].MoistureValueChanged += MoistureStamp.OnSetData;
        _nameText.text = name;
        _img.sprite = ResourceManager.Instance.GetImportImage(id);
    }
    
    public void OnClickShowPlantInfo()
    {
        _uiViewManager.OnShowPlantInfoPanel();
    }
}