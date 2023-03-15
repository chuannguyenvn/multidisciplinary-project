using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlantListItemView : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _name = null;
    [SerializeField]
    private Image _img = null;
    [Space]
    public PlantInformationStamp LightStamp = null;
    public PlantInformationStamp TempStamp = null;
    public PlantInformationStamp HumidStamp = null;

    public void SetPlantItem(string name, string id)
    {
        _name.text = name;
        _img.sprite = ResourceManager.Instance.GetImportImage(id);
    }
    public void OnClickShowPlantInfo()
    {

    }
}