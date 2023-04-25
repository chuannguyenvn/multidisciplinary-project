using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlantListView : MonoBehaviour
{
    [SerializeField] private PlantListItemView _prefabPlantItem = null;
    [SerializeField] private GameObject _content = null;

    [SerializeField]
    private UIViewManager _uiViewManager = null;

    public void Init()
    {
        _prefabPlantItem.gameObject.SetActive(false);
        Debug.LogError("check dct count: " + PlantManager.Instance.DctPlantData.Count);
        foreach (var plant in PlantManager.Instance.DctPlantData)
        {
            //Debug.LogError("plant id: " + plant.Key);
            var item = Utility.InstantiateObject<PlantListItemView>(_prefabPlantItem, _content.transform);
            item.SetPlantData(plant.Key, plant.Value.PlantName, "Plant Image", plant.Value.LightValue, plant.Value.TemperatureValue, plant.Value.MoistureValue);
            item.gameObject.SetActive(true);
        }
        _uiViewManager.OnClickShowViewListPlant();
        _uiViewManager.NewPlantName = "";
        _uiViewManager.OnShowWaitingScene(false);
    }
    public void OnClickButtonAddNewPlant()
    {
        _uiViewManager.GetUIViewWithViewName(Define.ViewName.NewPlant.ToString()).gameObject.SetActive(true);
        _uiViewManager.OnShowWaitingScene(false);
    }
    public void OnClickCancelAddPlant()
    {
        _uiViewManager.OnClickShowViewListPlant();
        _uiViewManager.NewPlantName = "";
    }
    public void OnClickSpawnPlantItems()
    {
        //gui request tao cay moi va lay data ve, sau do generate data controller
        var newName = Utility.RemoveSpacesFromHeadTail(_uiViewManager.NewPlantName);
        StartCoroutine(OnClick(_uiViewManager.NewPlantName));
        Debug.LogError("childcount: " + _content.transform.childCount);
        for (var i = 1; i < _content.transform.childCount; i++)
        {
            Destroy(_content.transform.GetChild(i).gameObject);
        }

        _uiViewManager.OnClickShowViewListPlant();
        _uiViewManager.NewPlantName = "";
    }
    public IEnumerator OnClick(string name)
    {
        _uiViewManager.OnShowWaitingScene(true);
        yield return ResourceManager.Instance.RequestAddNewPlant(name);
        yield return new WaitForSeconds(6);
        Init();
    }
}