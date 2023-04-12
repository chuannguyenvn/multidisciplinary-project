using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.ARFoundation;
public class ImageRecognition : MonoBehaviour
{
    private ARTrackedImageManager _arTrackedImageManager;
    [SerializeField]
    private GameObject _panel = null;

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
    }
}
