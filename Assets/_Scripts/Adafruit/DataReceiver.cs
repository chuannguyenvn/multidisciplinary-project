using System;
using UnityEngine;

namespace Adafruit
{
    public class DataReceiver : DataWorker
    {
        public Action<string> OnMessageReceived;
        protected string LastReceivedMessage;
        protected bool AutoLog = true;

        protected virtual void Start()
        {
            AdafruitManager.Instance.SubscribeTopic(TopicPath);
            AdafruitManager.Instance.MessageReceived += MessageReceivedHandler;
        }

        protected virtual void OnDestroy()
        {
            AdafruitManager.Instance.UnsubscribeTopic(TopicPath);
            AdafruitManager.Instance.MessageReceived -= MessageReceivedHandler;
        }

        private void MessageReceivedHandler(string topic, string message)
        {
            if (topic.Contains(TopicPath))
            {
                OnMessageReceived?.Invoke(message);
                LastReceivedMessage = message;
                if (AutoLog) LogMessage(message);
            }
        }

        public override void SetTopic(HistoryType historyType)
        {
            AdafruitManager.Instance.UnsubscribeTopic(TopicPath);
            base.SetTopic(historyType);
            AdafruitManager.Instance.SubscribeTopic(TopicPath);
        }
    }
}