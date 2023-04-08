using System;
using System.Collections.Generic;
using Adafruit;
using UnityEngine;

public class PlantManager : Singleton<PlantManager>
{
    private List<string> _plantNames = new List<string>();
    public Dictionary<string, PlantDataController> PlantDataControllersByName = new Dictionary<string, PlantDataController>();

    public List<string> ListPlantName
    {
        get => _plantNames;
        set => _plantNames = value;
    }
    public bool OnCheckNameAlreadyUsed(string name)
    {
        name = Utility.RemoveSpacesFromHeadTail(name);
        return _plantNames.Contains(name);
    }
    private void Start()
    {
        //lay data tu database vao list plantname sau do chay cai ben duoi de set up data controller cho tung plant

        foreach (var plantName in _plantNames)
        {
            var dataController = Instantiate(ResourceManager.Instance.PlantDataController, transform);
            dataController.Init(plantName);
            PlantDataControllersByName.Add(plantName, dataController);
        }
    }
    public void InstantiateDataController(string plantName)
    {
        var dataController = Instantiate(ResourceManager.Instance.PlantDataController, transform);
        dataController.Init(plantName);
        PlantDataControllersByName.Add(plantName, dataController);
        _plantNames.Add(plantName);
        CheckPlant();
    }
    private void CheckPlant()
    {
        foreach (var plant in _plantNames)
            Debug.LogError("name: " + plant);
    }
}