using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIViewManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _panelHistory = null;
    [SerializeField]
    private GameObject _topMenu = null;
    [SerializeField]
    private GameObject _textNameUsed = null;
    [SerializeField]
    private TMP_InputField _inputName = null;
    [SerializeField]
    private TMP_InputField _inputID = null;

    public Dictionary<string, UIView> DictUIView = new Dictionary<string, UIView>();
    private List<string> _lstShownView;
    public List<string> LstShownView
    {
        get
        {
            if (_lstShownView == null) _lstShownView = new List<string>();
            return _lstShownView;
        }
        set => _lstShownView = value;
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
    private void Awake()
    {
        Initialize();
        //SceneManager.Instance.ShowPanelInfor += OnClickShowViewPlantInfor;
        //SceneManager.Instance.ShowAccount += OnClickShowViewAccount;
        //SceneManager.Instance.ShowListPlant += OnClickShowViewListPlant;
        //SceneManager.Instance.Init += Initialize;
    }
    private void Start()
    {
        OnClickShowViewListPlant();
        var param = SceneManager.Instance.CurrentParam;
        if (param != null)
        {
            switch (param.viewName)
            {
                case Define.ViewName.PlantInfor:
                    OnShowPlantInfoPanel();
                    break;

                case Define.ViewName.Account:
                    OnClickShowViewAccount();
                    break;

                default:
                    break;
            }
        }
    }
    private void Initialize()
    {
        UIView[] viewController = GetComponentsInChildren<UIView>(true);
        foreach (var view in viewController)
        {
            view.Initialize(this);
            if (!DictUIView.ContainsKey(view.ViewName))
                DictUIView.Add(view.ViewName, view);
            else Debug.LogError("trung");
        }
        //Debug.LogError("count of dct: " + DictUIView.Count);
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
        _topMenu.SetActive(true);
        LstShownView.Add(Define.ViewName.ListPlant.ToString());
    }
    public void OnClickShowViewARMode()
    {
        SceneManager.Instance.ChangeScene(Define.SceneName.AR.ToString(), null);
    }
    public void OnClickShowViewAccount()
    {
        foreach (var pair in DictUIView)
        {
            if (pair.Key == Define.ViewName.Account.ToString())
                pair.Value.gameObject.SetActive(true);
            else pair.Value.gameObject.SetActive(false);
        }
        NewPlantID = NewPlantName = "";
        LstShownView.Add(Define.ViewName.Account.ToString());
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

    #region Plant Infor
    public void OnShowPlantInfoPanel()
    {
        OnClickShowViewPlantInfor();
        _topMenu.SetActive(false);
    }
    public void OnClickShowViewPlantInfor()
    {
        foreach (var pair in DictUIView)
        {
            if (pair.Key == Define.ViewName.PlantInfor.ToString())
                pair.Value.gameObject.SetActive(true);
            else pair.Value.gameObject.SetActive(false);
        }
        NewPlantID = NewPlantName = "";
        LstShownView.Add(Define.ViewName.PlantInfor.ToString());
    }
    public void OnClickBackToListPlant()
    {
        OnClickShowViewListPlant();
    }
    public void OnClickBtnInforStamp()
    {
        //lay infor cua cay dc target
        //lay = plantlistviewitem roi reference sang inforStamp
        //show panel history

    }

    #endregion
}
