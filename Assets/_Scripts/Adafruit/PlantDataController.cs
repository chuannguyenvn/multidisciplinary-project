using System;
using UnityEngine;

public class PlantDataController : MonoBehaviour
{
    [HideInInspector]
    public int Id;
    [HideInInspector]
    public string PlantName;
    [HideInInspector]
    public DateTime CreatedDate;
    [HideInInspector]
    public string RecognizerCode;
    [HideInInspector]
    public DateTime Timestamp;
    [HideInInspector]
    public double LightValue;
    [HideInInspector]
    public double TemperatureValue;
    [HideInInspector]
    public double MoistureValue;

    public void Init(int id, string name, DateTime date, string code)
    {
        Id = id;
        PlantName = name;
        CreatedDate = date;
        RecognizerCode = code;
    }
}