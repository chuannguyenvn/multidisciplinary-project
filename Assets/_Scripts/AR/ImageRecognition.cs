using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.XR.ARFoundation;
using UnityEngine.UI;
using TMPro;

public class ImageRecognition : MonoBehaviour
{
    private ARTrackedImageManager _arTrackedImageManager;
    [SerializeField]
    private GameObject _panel = null;
    //[SerializeField]
    //private TextMeshProUGUI _text = null;

    private void Awake()
    {
        _arTrackedImageManager = GetComponent<ARTrackedImageManager>();
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
        //var str = "";
        //foreach (var trackImage in _arTrackedImageManager.trackables)
        //{
        //    Debug.LogError("trackImage name: " + trackImage.referenceImage.name);
        //    str += trackImage.referenceImage.name;
        //}
        //_text.text = str;
        //foreach (var evt in args.added)
        //{
        //    Debug.LogError("evt name: " + evt.referenceImage.name);
        //}
    }
    //public void OnClickTest()
    //{
    //    Debug.LogError("on click test");
    //    AddImage(_img.sprite.texture);
    //}
    //void AddImage(Texture2D imageToAdd)
    //{
    //    Debug.LogError("on add img");
    //    var library = _arTrackedImageManager.CreateRuntimeLibrary();
    //    if (library is MutableRuntimeReferenceImageLibrary mutableLibrary)
    //    {
    //        mutableLibrary.ScheduleAddImageWithValidationJob(
    //            imageToAdd,
    //            "my new image",
    //            0.5f /* 50 cm */);
    //    }
    //}
}
