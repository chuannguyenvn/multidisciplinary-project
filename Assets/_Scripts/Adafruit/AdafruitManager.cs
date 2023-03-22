using System;
using System.Collections.Generic;
using Adafruit;
using M2MqttUnity;
using M2MqttUnity.Examples;
using UnityEngine;

public class AdafruitManager : PersistentSingleton<AdafruitManager>
{
    public event Action<bool> LoginStatusReceived;

    public string Username;

    [SerializeField] private M2MqttUnityTest mqttUnityClient;
    [SerializeField] private MqttReceiver mqttReceiver;
    [SerializeField] private MqttController mqttController;

    public Action<string, string> MessageReceived;

    private void Start()
    {
        mqttUnityClient.ConnectionSucceeded += ConnectionSucceededHandler;
        mqttUnityClient.ConnectionFailed += ConnectionFailedHandler;
    }

    public void TryConnect(string username, string key)
    {
        mqttUnityClient.SetLoginCredentials(username, key);
        mqttUnityClient.Connect();
        Username = username;
    }

    private void ConnectionSucceededHandler()
    {
        mqttUnityClient.OnMessageReceived += (topic, message) => MessageReceived?.Invoke(topic, message);
        LoginStatusReceived?.Invoke(true);
    }

    private void ConnectionFailedHandler()
    {
        LoginStatusReceived?.Invoke(false);
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