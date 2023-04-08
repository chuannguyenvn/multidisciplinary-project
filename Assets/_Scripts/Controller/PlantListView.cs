using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlantListView : MonoBehaviour
{
    [SerializeField] private PlantListItemView _prefabPlantItem = null;
    [SerializeField] private GameObject _content = null;

    [SerializeField] private TMP_InputField _inputName = null;
    [SerializeField] private TMP_InputField _inputID = null;
    [SerializeField] private GameObject _textNameUsed = null;
    [SerializeField] private GameObject _panelNewPlant = null;

    private void Awake()
    {
        _panelNewPlant.SetActive(false);
        _textNameUsed.SetActive(false);
        _prefabPlantItem.gameObject.SetActive(false);
    }
    public void OnClickButtonAddNewPlant()
    {
        _panelNewPlant.SetActive(true);
    }
    public void OnClickSpawnPlantItems()
    {
        if (PlantManager.Instance.OnCheckNameAlreadyUsed(_inputName.text))
        {
            _textNameUsed.SetActive(true);
            return;
        }
        var newName = Utility.RemoveSpacesFromHeadTail(_inputName.text);
        //var newID = Utility.RemoveSpacesFromHeadTail(_inputID.text);
        var newID = _inputID.text;
        var item = Utility.InstantiateObject<PlantListItemView>(_prefabPlantItem, _content.transform);
        PlantManager.Instance.InstantiateDataController(newName);
        item.SetPlantItem(newName, newID);
        item.gameObject.SetActive(true);
        _panelNewPlant.SetActive(false);
        _inputName.text = _inputID.text = "";
        _textNameUsed.SetActive(false);
    }
}