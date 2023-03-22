using System;
using System.Collections.Generic;
using Adafruit;
using M2MqttUnity;
using M2MqttUnity.Examples;
using UnityEngine;

public class AdafruitManager : PersistentSingleton<AdafruitManager>
{
    public string Username;

    [SerializeField] private M2MqttUnityTest mqttUnityClient;
    [SerializeField] private MqttReceiver mqttReceiver;
    [SerializeField] private MqttController mqttController;

    public Action<string, string> MessageReceived;

    private List<string> _plantNames = new() {"dadn"};

    public Dictionary<string, PlantDataController> PlantDataControllersByName = new();


    private void Start()
    {
        mqttUnityClient.ConnectionSucceeded += Init;
    }


    private void Init()
    {
        foreach (var plantName in _plantNames)
        {
            var dataController = Instantiate(ResourceManager.Instance.PlantDataController, transform);
            dataController.Init(plantName);
            PlantDataControllersByName.Add(plantName, dataController);
        }

        mqttUnityClient.OnMessageReceived += (topic, message) => MessageReceived?.Invoke(topic, message);
    }

    public void SendMessage(string topic, string content)
    {
        mqttUnityClient.ExecuteAction(() => mqttUnityClient.Publish(topic, content));
    }

    public void SubscribeTopic(string topic)
    {
        mqttUnityClient.ExecuteAction(() => mqttUnityClient.SubscribeTopic(topic));
    }

    public void UnsubscribeTopic(string topic)
    {
        mqttUnityClient.ExecuteAction(() => mqttUnityClient.UnsubscribeTopic(topic));
    }

    public string ConstructTopicPathString(string topic)
    {
        return Username + "/feeds/" + topic;
    }
}