using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIViewManager : MonoBehaviour
{
    [Header("View")]
    [SerializeField]
    private GameObject _viewListPlant = null;
    [SerializeField]
    private GameObject _viewARMode = null;
    [SerializeField]
    private GameObject _viewMyAccount = null;
    [SerializeField]
    private GameObject _viewNewPlant = null;
    [SerializeField]
    private GameObject _viewPlantInformation = null;
    [Space]
    [SerializeField]
    private GameObject _topMenu = null;
    [SerializeField]
    private GameObject _textNameUsed = null;
    [SerializeField]
    private TMP_InputField _inputName = null;
    [SerializeField]
    private TMP_InputField _inputID = null;

    public Dictionary<string, UIView> DictUIView = new Dictionary<string, UIView>();

    private void Awake()
    {
        Initialize();
    }
    private void Start()
    {
        OnClickShowViewListPlant();
    }
    private void Initialize()
    {
        UIView[] viewController = GetComponentsInChildren<UIView>(true);
        foreach (var view in viewController)
        {
            view.Initialize(this);
            DictUIView.Add(view.ViewName, view);
        }
        //Debug.LogError("count of dct: " + DictUIView.Count);
    }
    public string NewPlantName
    {
        get => _inputName.text;
        set => _inputName.text = value;
    }
    public string NewPlantID
    {
        get => _inputID.text;
        set => _inputID.text = value;
    }
    public void OnClickShowViewListPlant()
    {
        foreach (var pair in DictUIView)
        {
            if (pair.Key == Define.ViewName.ListPlant.ToString())
                pair.Value.gameObject.SetActive(true);
            else pair.Value.gameObject.SetActive(false);
        }
        _textNameUsed.SetActive(false);
    }
    public void OnClickShowViewARMode()
    {
        foreach (var pair in DictUIView)
        {
            if (pair.Key == Define.ViewName.ARMode.ToString())
                pair.Value.gameObject.SetActive(true);
            else pair.Value.gameObject.SetActive(false);
        }
    }
    public void OnClickShowViewAccount()
    {
        foreach (var pair in DictUIView)
        {
            if (pair.Key == Define.ViewName.Account.ToString())
                pair.Value.gameObject.SetActive(true);
            else pair.Value.gameObject.SetActive(false);
        }
    }
    public UIView GetUIViewWithViewName(string name)
    {
        foreach (var pair in DictUIView)
        {
            if (pair.Key == name)
                return pair.Value;
        }
        return null;
    }
    public void SetTextNameUsed(bool status)
    {
        _textNameUsed.SetActive(status);
    }

    public void OnShowPlantInfoPanel()
    {
        _viewPlantInformation.SetActive(true);
    }
}
