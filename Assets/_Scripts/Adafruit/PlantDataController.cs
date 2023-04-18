using System;
using UnityEngine;

public class PlantDataController : MonoBehaviour
{
    private int Id;
    private string Name;
    private DateTime CreatedDate;
    private string RecognizerCode;

    public void Init(int id, string name, DateTime date, string code)
    {
        Id = id;
        Name = name;
        CreatedDate = date;
        RecognizerCode = code;
    }
}