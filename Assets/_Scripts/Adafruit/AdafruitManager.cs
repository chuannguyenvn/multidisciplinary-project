using System;
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

    private void Start()
    {
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