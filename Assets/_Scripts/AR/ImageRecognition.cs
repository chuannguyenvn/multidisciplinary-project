using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.ARFoundation;
using TMPro;

public class ImageRecognition : MonoBehaviour
{
    private ARTrackedImageManager _arTrackedImageManager;
    [SerializeField]
    private GameObject _panel = null;
    //[SerializeField]
    //private TextMeshProUGUI _text = null;
    //[SerializeField]
    //private TextMeshProUGUI _text2 = null;
    //[SerializeField]
    //private TextMeshProUGUI _text3 = null;
    //[SerializeField]
    //private TextMeshProUGUI _text4 = null;
    //[SerializeField]
    //private TextMeshProUGUI _text5 = null;

    private void Awake()
    {
        _arTrackedImageManager = GetComponent<ARTrackedImageManager>();
    }
    private void Start()
    {
        _panel.SetActive(false);
        //_text4.text = "start";
    }
    public void OnEnable()
    {
        _arTrackedImageManager.trackedImagesChanged += OnShowPanel;
    }
    public void OnDisable()
    {
        _arTrackedImageManager.trackedImagesChanged -= OnShowPanel;
    }

    public void OnShowPanel(ARTrackedImagesChangedEventArgs args)
    {
        _panel.SetActive(true);
        var str = "";
        foreach (var item in _arTrackedImageManager.trackables)
        {
            str += item.referenceImage.name;
        }
        //_text.text = str;
        //foreach (var item in args.added)
        //{
        //    _text2.text = "name " + item.referenceImage.name;
        //    _text3.text = "tracking state: " + item.trackingState.ToString();
        //}
        //foreach (var item in args.removed)
        //{
        //    _text5.text = item.referenceImage.name;
        //}
    }
}
