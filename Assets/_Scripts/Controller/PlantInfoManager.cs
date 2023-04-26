using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlantInfoManager : MonoBehaviour
{
    [SerializeField]
    private UIViewManager _uiViewManager = null;
    [SerializeField]
    private TextMeshProUGUI _light = null;
    [SerializeField]
    private TextMeshProUGUI _humid = null;
    [SerializeField]
    private TextMeshProUGUI _temp = null;

    public void OnClickShowHistoryTemp()
    {
        _uiViewManager.OnClickShowViewHistory();
        PlantHistory.Instance.OnChangeHistoryType(Define.HistoryType.Temperature);
    }
    public void OnClickShowHistoryLight()
    {
        _uiViewManager.OnClickShowViewHistory();
        PlantHistory.Instance.OnChangeHistoryType(Define.HistoryType.Light);
    }
    public void OnClickShowHistoryHumid()
    {
        _uiViewManager.OnClickShowViewHistory();
        PlantHistory.Instance.OnChangeHistoryType(Define.HistoryType.Humidity);
    }
    public void OnClickBackBtn()
    {
        _uiViewManager.OnClickBackToListPlant();
    }
    public void OnClickWaterNow()
    {
        Debug.LogError("click water " + PlantManager.Instance.CurrentPlantItem.PlantID);
        StartCoroutine(ResourceManager.Instance.RequestWaterNow(PlantManager.Instance.CurrentPlantItem.PlantID));
    }
    public void OnClickEdit()
    {
        _uiViewManager.OnClickShowViewEdit();
    }
    public void OnSetPlantData(string light, string humid, string temp)
    {
        _temp.text = temp;
        _light.text = light;
        _humid.text = humid;
    }
}
