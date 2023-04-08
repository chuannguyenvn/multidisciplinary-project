using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Adafruit
{
    public abstract class DataWorker : MonoBehaviour
    {
        public string PlantName;
        public string Topic;
        //public string TopicPath => AdafruitManager.Instance.ConstructTopicPathString(PlantName + '.' + Topic);
        public string TopicPath;
        public List<CommunicationLog> History = new();

        public void LogMessage(string content)
        {
            History.Add(new CommunicationLog(DateTime.Now, content));
        }
    }

    public class CommunicationLog
    {
        public readonly DateTime Timestamp;
        public readonly string Content;

        public CommunicationLog(DateTime timestamp, string content)
        {
            Timestamp = timestamp;
            Content = content;
        }
    }
}