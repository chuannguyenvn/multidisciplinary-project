using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIViewManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _viewListPlant = null;
    [SerializeField]
    private GameObject _viewARMode = null;
    [SerializeField]
    private GameObject _viewMyAccount = null;
    [SerializeField]
    private GameObject _viewNewPlant = null;
    [SerializeField]
    private GameObject _textNameUsed = null;
    [SerializeField]
    private TMP_InputField _inputName = null;
    [SerializeField]
    private TMP_InputField _inputID = null;

    private void Start()
    {
        OnClickShowViewListPlant();
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
        _viewListPlant.SetActive(true);
        _viewARMode.SetActive(false);
        _viewMyAccount.SetActive(false);
        _viewNewPlant.SetActive(false);
        _textNameUsed.SetActive(false);
    }
    public void OnClickShowViewARMode()
    {
        _viewListPlant.SetActive(false);
        _viewARMode.SetActive(true);
        _viewMyAccount.SetActive(false);
    }
    public void OnClickShowViewAccount()
    {
        _viewListPlant.SetActive(false);
        _viewARMode.SetActive(false);
        _viewMyAccount.SetActive(true);
    }
    public void SetTextNameUsed(bool status)
    {
        _textNameUsed.SetActive(status);
    }
    public void SetPanelNewPlant(bool status)
    {
        _viewNewPlant.SetActive(status);
    }
}
