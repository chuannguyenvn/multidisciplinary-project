using System;
using System.Collections;
using UnityEngine;


public class Test : MonoBehaviour
{
    public string SubscribedTopic = "plant-1.light";
    
    private IEnumerator Start()
    {

        yield return new WaitForSeconds(1f);
        AdafruitManager.Instance.SubscribeTopic("chuanpro030/feeds/" + SubscribedTopic);
        AdafruitManager.Instance.MessageReceived += (t, s) => Debug.Log("from " + t + ": " + s);
        AdafruitManager.Instance.SendMessage("chuanpro030/feeds/" + SubscribedTopic, "10");
    }

    private void DecodeAndPrint(string s)
    {
        
    }
}