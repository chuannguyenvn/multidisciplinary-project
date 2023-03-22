using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantListView : MonoBehaviour
{
    [SerializeField] private PlantListItemView _prefabPlantItem = null;
    [SerializeField] private GameObject _content = null;

    public string name = "";
    public string id = "";

    private void Start()
    {
    }

    public void OnClickSpawnPlantItems()
    {
        var item = Utility.InstantiateObject<PlantListItemView>(_prefabPlantItem, _content.transform);
        item.SetPlantItem(name, id);
    }
}