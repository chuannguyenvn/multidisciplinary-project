using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantListView : MonoBehaviour
{
    [SerializeField]
    private PlantListItemView _prefabPlantItem = null;
    [SerializeField]
    private GameObject _content = null;

    private void Start()
    {
        SpawnPlantItems();
        SpawnPlantItems();
    }
    public void SpawnPlantItems()
    {
        Utility.InstantiateObject<PlantListItemView>(_prefabPlantItem, _content.transform);
    }
}
