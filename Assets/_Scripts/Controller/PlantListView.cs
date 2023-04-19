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
        foreach (var plant in PlantManager.Instance.DctPlantData)
        {
            var item = Utility.InstantiateObject<PlantListItemView>(_prefabPlantItem, _content.transform);
            PlantManager.Instance.InstantiateDataController(plant.Value.PlantName);
            item.SetPlantItem(plant.Value.PlantName, "Plant Image");
            item.gameObject.SetActive(true);
        }
    }
    public void OnClickButtonAddNewPlant()
    {
        _uiViewManager.GetUIViewWithViewName(Define.ViewName.NewPlant.ToString()).gameObject.SetActive(true);
    }
    public void OnClickCancelAddPlant()
    {
        _uiViewManager.OnClickShowViewListPlant();
        _uiViewManager.NewPlantName = "";
    }
    public void OnClickSpawnPlantItems()
    {
        //gui request tao cay moi va lay data ve, sau do generate data controller
        ResourceManager.Instance.RequestAddNewPlant(_uiViewManager.NewPlantName);

        var newName = Utility.RemoveSpacesFromHeadTail(_uiViewManager.NewPlantName);
        var item = Utility.InstantiateObject<PlantListItemView>(_prefabPlantItem, _content.transform);
        PlantManager.Instance.InstantiateDataController(newName);
        item.SetPlantItem(newName, "Plant Image");
        item.gameObject.SetActive(true);

        _uiViewManager.OnClickShowViewListPlant();
        _uiViewManager.NewPlantName = "";
    }
}