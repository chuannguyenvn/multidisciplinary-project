using System;
using System.Collections.Generic;
using UnityEngine;

public class PlantManager : PersistentSingleton<PlantManager>
{
    //private List<string> _plantNames = new List<string>();
    public Dictionary<int, PlantDataController> DctPlantData = new Dictionary<int, PlantDataController>();

    //public List<string> ListPlantName
    //{
    //    get => _plantNames;
    //    set => _plantNames = value;
    //}

    public void InstantiateDataController(string plantName)
    {
        //var dataController = Instantiate(ResourceManager.Instance.PlantDataController, transform);
        //dataController.Init(plantName);
        //DctPlantData.Add(plantName, dataController);
        //_plantNames.Add(plantName);
    }
}