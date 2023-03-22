using System;
using UnityEngine;

namespace Adafruit
{
    public class PlantDataController : MonoBehaviour
    {
        [SerializeField] private DataSender _lightDataSender;
        [SerializeField] private DataReceiver _lightDataReceiver;
        public event Action<string> LightValueChanged;

        [SerializeField] private DataSender _temperatureDataSender;
        [SerializeField] private DataReceiver _temperatureDataReceiver;
        public event Action<string> TemperatureValueChanged;

        [SerializeField] private DataSender _moistureDataSender;
        [SerializeField] private DataReceiver _moistureDataReceiver;
        public event Action<string> MoistureValueChanged;

        public void Init(string plantName)
        {
            _lightDataSender.PlantName = _lightDataReceiver.PlantName = plantName;
            _lightDataSender.Topic = _lightDataReceiver.Topic = Constants.TOPIC_LIGHT;
            _lightDataReceiver.OnMessageReceived += value => LightValueChanged?.Invoke(value);
            _lightDataReceiver.gameObject.SetActive(true);

            _temperatureDataSender.PlantName = _temperatureDataReceiver.PlantName = plantName;
            _temperatureDataSender.Topic = _temperatureDataReceiver.Topic = Constants.TOPIC_TEMPERATURE;
            _temperatureDataReceiver.OnMessageReceived += value => TemperatureValueChanged?.Invoke(value);
            _temperatureDataReceiver.gameObject.SetActive(true);

            _moistureDataSender.PlantName = _moistureDataReceiver.PlantName = plantName;
            _moistureDataSender.Topic = _moistureDataReceiver.Topic = Constants.TOPIC_MOISTURE;
            _moistureDataReceiver.OnMessageReceived += value => MoistureValueChanged?.Invoke(value);
            _moistureDataReceiver.gameObject.SetActive(true);
        }
    }
}