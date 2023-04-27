using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlantInfoManager : MonoBehaviour
{
    [SerializeField]
    private UIViewManager _uiViewManager = null;
    [SerializeField]
    private TextMeshProUGUI _name = null;
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
        StartCoroutine(OnWaterNow());
    }
    private IEnumerator OnWaterNow()
    {
        yield return ResourceManager.Instance.RequestWaterNow(PlantManager.Instance.CurrentPlantItem.PlantID);
        if (!ResourceManager.Instance.CanWater)
        {
            _uiViewManager.OnSetNotiPanel(true, "Cannot Water Now");
            yield return new WaitForSeconds(2);
            _uiViewManager.OnSetNotiPanel(false, "");
        }
        else
        {

        }
    }
    public void OnClickEdit()
    {
        _uiViewManager.OnClickShowViewEdit();
    }
    public void OnSetPlantData(string name, string light, string humid, string temp)
    {
        _name.text = name;
        _temp.text = temp;
        _light.text = light;
        _humid.text = humid;
    }
}
