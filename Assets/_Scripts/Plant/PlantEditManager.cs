using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.XR;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlantEditManager : MonoBehaviour
{
    [Header("Plant Name")]
    [SerializeField]
    private TMP_InputField _name = null;
    [SerializeField]
    private Image _imgInput = null;
    [Header("Change Waterring Rules")]
    [SerializeField]
    private GameObject _panelChangeRules = null;
    [Header("Remove")]
    [SerializeField]
    private GameObject _panelRemove = null;
    [SerializeField]
    private TMP_InputField _newRules = null;
    [Space]
    [SerializeField]
    private Image _imgPlant = null;

    private Texture2D _texture = null;
    public void Init()
    {
        _imgInput.enabled = false;
        _name.interactable = false;
    }
    public void OnClickRenameBtn()
    {
        _imgInput.enabled = true;
        _name.interactable = true;
    }
    public void OnUnActiveInputName()
    {
        _name.interactable = false;
        _imgInput.enabled = false;
    }
    public void OnClickSaveRecog()
    {
        SaveImage();
    }
    public void OnClickRetakeBtn()
    {
        //access to gallery and select picture
        PickImage();
    }
    public void OnClickChangeRules()
    {
        _panelChangeRules.SetActive(true);
    }
    public void OnClickExportLog()
    {

    }
    public void OnClickRemoveBtn()
    {

    }
    public void OnClickConfirmChangeRulesBtn()
    {
        _panelChangeRules.SetActive(false);
        //gui text len server
        StartCoroutine(OnClickSendRequestChangeRules());
    }
    private IEnumerator OnClickSendRequestChangeRules()
    {
        int curID = PlantManager.Instance.CurrentPlantItem.PlantID;
        Debug.LogError("cur Id: " + curID);
        yield return ResourceManager.Instance.RequestChangeWaterRules(curID, _newRules.text, PlantManager.Instance.DctPlantData[curID].PlantName);
        //yield return ResourceManager.Instance.RequestGetLatestData(PlantManager.Instance.CurrentPlantItem.PlantID);
        _panelChangeRules.SetActive(false);
    }
    public void OnClickCancelChangeRulesBtn()
    {
        _panelChangeRules.SetActive(false);
    }
    public void OnClickConfirmRemoveBtn()
    {
        _panelRemove.SetActive(false);
        //gui request len server
    }
    public void OnClickCancelRemoveBtn()
    {
        _panelRemove.SetActive(false);
    }
    public void PickImage()
    {
        NativeGallery.Permission permission = NativeGallery.GetImageFromGallery((path) =>
        {
            Debug.Log("Image path: " + path);
            if (path != null)
            {
                // Create Texture from selected image
                Texture2D texture = NativeGallery.LoadImageAtPath(path);
                if (texture == null)
                {
                    Debug.Log("Couldn't load texture from " + path);
                    return;
                }
                _texture = texture;
                _imgPlant.sprite = Utility.ConvertToSprite(texture);
            }
        });

        Debug.Log("Permission result: " + permission);
    }
    public void SaveImage()
    {
        Debug.LogError("save image");

        NativeGallery.Permission permission = NativeGallery.SaveImageToGallery(_texture, "GalleryTest", "quangbao.png", (success, path) => Debug.Log("Media save result: " + success + " " + path));

        Debug.LogError("Permission result: " + permission);
    }
    
}
