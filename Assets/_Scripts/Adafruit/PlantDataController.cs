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

    public void Init(int id, string name, DateTime date, string code)
    {
        Id = id;
        PlantName = name;
        CreatedDate = date;
        RecognizerCode = code;
    }
}