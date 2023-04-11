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

    private void Awake()
    {
        _prefabPlantItem.gameObject.SetActive(false);
    }
    public void OnClickButtonAddNewPlant()
    {
        _uiViewManager.GetUIViewWithViewName(Define.ViewName.NewPlant.ToString()).gameObject.SetActive(true);
    }
    public void OnClickCancelAddPlant()
    {
        _uiViewManager.OnClickShowViewListPlant();
        _uiViewManager.SetTextNameUsed(false);
        _uiViewManager.NewPlantName = _uiViewManager.NewPlantID = "";
    }
    public void OnClickSpawnPlantItems()
    {
        if (PlantManager.Instance.OnCheckNameAlreadyUsed(_uiViewManager.NewPlantName))
        {
            _uiViewManager.SetTextNameUsed(true);
            return;
        }
        var newName = Utility.RemoveSpacesFromHeadTail(_uiViewManager.NewPlantName);
        //var newID = Utility.RemoveSpacesFromHeadTail(_inputID.text);
        var newID = _uiViewManager.NewPlantID;
        var item = Utility.InstantiateObject<PlantListItemView>(_prefabPlantItem, _content.transform);
        PlantManager.Instance.InstantiateDataController(newName);
        item.SetPlantItem(newName, "Plant Image");
        item.gameObject.SetActive(true);

        _uiViewManager.OnClickShowViewListPlant();
        _uiViewManager.SetTextNameUsed(false);
        _uiViewManager.NewPlantName = _uiViewManager.NewPlantID = "";
    }
}