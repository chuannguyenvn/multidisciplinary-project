using System;
using UnityEngine;

namespace Adafruit
{
    public class DataSender : DataWorker
    {
        public void SendMessage(string content)
        {
            AdafruitManager.Instance.SendMessage(TopicPath, content);
        }
    }
}