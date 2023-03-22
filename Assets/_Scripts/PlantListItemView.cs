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

    private void Start()
    {
        SetPlantItem("dadn", "");
    }

    public void SetPlantItem(string name, string id)
    {
        AdafruitManager.Instance.PlantDataControllersByName[name].LightValueChanged += LightStamp.OnSetData;
        AdafruitManager.Instance.PlantDataControllersByName[name].TemperatureValueChanged += TempStamp.OnSetData;
        AdafruitManager.Instance.PlantDataControllersByName[name].MoistureValueChanged += MoistureStamp.OnSetData;
        _nameText.text = name;
        _img.sprite = ResourceManager.Instance.GetImportImage(id);
    }
    
    public void OnClickShowPlantInfo()
    {
        
    }
}