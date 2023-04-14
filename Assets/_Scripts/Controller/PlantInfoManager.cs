using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantInfoManager : MonoBehaviour
{
    [SerializeField]
    private UIViewManager _uiViewManager = null;
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
        Debug.LogError("click water");
    }
    public void OnClickEdit()
    {
        Debug.LogError("click edit");
        _uiViewManager.OnClickShowViewEdit();
    }

}
