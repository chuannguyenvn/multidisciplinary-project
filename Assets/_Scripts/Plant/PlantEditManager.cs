using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlantEditManager : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField _name = null;
    [SerializeField]
    private Image _imgInput = null;
    [SerializeField]
    private GameObject _panelChangeRules = null;
    [SerializeField]
    private TMP_InputField _newRules = null;
    [Space]
    [SerializeField]
    private Image _imgPlant = null;

    private void Start()
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
    public void OnClickConfirmBtn()
    {
        _panelChangeRules.SetActive(false);
        //gui text len server
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
                _imgPlant.sprite = Utility.ConvertToSprite(texture);

                // If a procedural texture is not destroyed manually, 
                // it will only be freed after a scene change
                //Destroy(texture, 5f);
            }
        });

        Debug.Log("Permission result: " + permission);
    }
}
