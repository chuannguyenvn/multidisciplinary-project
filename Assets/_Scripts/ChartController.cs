using System;
using System.Collections.Generic;
using Adafruit;
using UnityEngine;

public class ChartController : MonoBehaviour
{
    [SerializeField] private List<BarUnit> _barUnits;
    [SerializeField] private DataReceiver _dataReceiver;

    private void Update()
    {
        for (int i = 0; i < _barUnits.Count; i++)
        {
            _barUnits[^(i + 1)].SetPercentage(float.Parse(_dataReceiver.History[^(i + 1)].Content));
        }
    }
}