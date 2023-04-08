using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantListView : MonoBehaviour
{
    [SerializeField] private PlantListItemView _prefabPlantItem = null;
    [SerializeField] private GameObject _content = null;

    public string Name = "";
    public string Id = "";

    private void Start()
    {
    }

    public void OnClickSpawnPlantItems()
    {
        var item = Utility.InstantiateObject<PlantListItemView>(_prefabPlantItem, _content.transform);
        PlantManager.Instance.InstantiatePlantDataController(Name);
        item.SetPlantItem(Name, Id);
    }
}