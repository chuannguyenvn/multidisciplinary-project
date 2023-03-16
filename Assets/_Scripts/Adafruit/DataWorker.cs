using System;
using System.Collections;
using UnityEngine;

namespace Adafruit
{
    public abstract class DataWorker : MonoBehaviour
    {
        public string PlantName;
        public string Topic;
        public string TopicPath => AdafruitManager.Instance.ConstructTopicPathString(PlantName + '.' + Topic);

        private IEnumerator Start()
        {
            yield return new WaitForSeconds(2f);
        }

        public virtual void SetTopic(HistoryType historyType)
        {
            Topic = historyType switch
            {
                HistoryType.Light => "light",
                HistoryType.Temperature => "temperature",
                HistoryType.Humidity => "humidity",
            };
        }
    }
}