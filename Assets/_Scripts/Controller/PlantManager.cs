using System;
using System.Collections.Generic;
using Adafruit;
using UnityEngine;

public class PlantManager : Singleton<PlantManager>
{
    private List<string> _plantNames = new() {"dadn"};
    public Dictionary<string, PlantDataController> PlantDataControllersByName = new();

    private void Start()
    {
        foreach (var plantName in _plantNames)
        {
            var dataController = Instantiate(ResourceManager.Instance.PlantDataController, transform);
            dataController.Init(plantName);
            PlantDataControllersByName.Add(plantName, dataController);
        }
    }
}