using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantController : MonoBehaviour
{
    [SerializeField]
    private PlantItem _prefabPlantItem = null;
    [SerializeField]
    private GameObject _content = null;

    private void Start()
    {
        SpawnPlantItems();
        SpawnPlantItems();
    }
    public void SpawnPlantItems()
    {
        Utility.InstantiateObject<PlantItem>(_prefabPlantItem, _content.transform);
    }
}
